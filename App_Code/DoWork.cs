using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


/// <summary>
/// Wraps department details data
/// </summary>
public struct DepartmentDetails
{
    public string Name;
    public string Description;
}

/// <summary>
/// Wraps category details data
/// </summary>
public struct CategoryDetails
{
    public int DepartmentId;
    public string Name;
    public string Description;
}

/// <summary>
/// Wraps product details data
/// </summary>
public struct ProductDetails
{
    public int ProductID;
    public string Name;
    public string Description;
    public decimal Price;
    public string Thumbnail;
    public string Image;
    public bool PromoFront;
    public bool PromoDept;
}

/// <summary>
/// Wraps order data
/// </summary>
public struct OrderInfo
{
    public int OrderID;
    public decimal TotalAmount;
    public string DateCreated;
    public string DateShipped;
    public bool Verified;
    public bool Completed;
    public bool Canceled;
    public string Comments;
    public string CustomerName;
    public string ShippingAddress;
    public string CustomerEmail;
}


/// <summary>
///DoWork 的摘要说明: 业务层
/// </summary>
public static class DoWork
{
	static DoWork()
	{
	}

    /// <summary>
    /// 转换参数
    /// </summary>
    /// <param name="ParamName">存储过程名称或命令文本</param>
    /// <param name="DbType">参数类型</param>
    /// <param name="Size">参数大小</param>
    /// <param name="Value">参数值</param>
    /// <returns>新的Parameter对象</returns>
    public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
    {
        return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
    }

    /// <summary>
    /// 初始化参数值
    /// </summary>
    /// <param name="ParamName">存储过程名称或命令文本</param>
    /// <param name="DbType">参数类型</param>
    /// <param name="Size">参数大小</param>
    /// <param name="Direction">参数方向</param>
    /// <param name="Value">参数值</param>
    /// <returns>新的 parameter 对象</returns>
    public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
    {
        SqlParameter param;

        if (Size > 0)
            param = new SqlParameter(ParamName, DbType, Size);
        else
            param = new SqlParameter(ParamName, DbType);

        param.Direction = Direction;
        if (!(Direction == ParameterDirection.Output && Value == null))
            param.Value = Value;
        return param;
    }

    // Retrieve the recent orders：获得最近的订单
    public static DataTable GetByRecent(int count)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrdersGetByRecent";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Count";
        param.Value = count;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the result table
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    //创建时间段中的订单
    // Retrieve orders that have been placed in a specified period of time
    public static DataTable GetByDate(string startDate, string endDate)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "OrdersGetByDate";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@StartDate";
        param.Value = startDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@EndDate";
        param.Value = endDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);
        // return the result table
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    // Retrieve orders that need to be verified or canceled
    public static DataTable GetUnverifiedUncanceled()
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrdersGetUnverifiedUncanceled";
        // return the result table
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    // Retrieve orders that need to be shipped/completed
    public static DataTable GetVerifiedUncompleted()
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "OrdersGetVerifiedUncompleted";
        // return the result table
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    // Retrieve order information
    public static OrderInfo GetInfo(string orderID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrderGetInfo";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderID";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // obtain the results
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        DataRow orderRow = table.Rows[0];
        // save the results into an OrderInfo object
        OrderInfo orderInfo;
        orderInfo.OrderID = Int32.Parse(orderRow["OrderID"].ToString());
        orderInfo.TotalAmount = Decimal.Parse(orderRow["TotalAmount"].ToString());
        orderInfo.DateCreated = orderRow["DateCreated"].ToString();
        orderInfo.DateShipped = orderRow["DateShipped"].ToString();
        orderInfo.Verified = bool.Parse(orderRow["Verified"].ToString());
        orderInfo.Completed = bool.Parse(orderRow["Completed"].ToString());
        orderInfo.Canceled = bool.Parse(orderRow["Canceled"].ToString());
        orderInfo.Comments = orderRow["Comments"].ToString();
        orderInfo.CustomerName = orderRow["CustomerName"].ToString();
        orderInfo.ShippingAddress = orderRow["ShippingAddress"].ToString();
        orderInfo.CustomerEmail = orderRow["CustomerEmail"].ToString();
        // return the OrderInfo object
        return orderInfo;
    }

    // Retrieve the order details (the products that are part of that order)
    public static DataTable GetDetails(string orderID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrderGetDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderID";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the results
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    // Update an order
    public static void Update(OrderInfo orderInfo)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrderUpdate";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderID";
        param.Value = orderInfo.OrderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DateCreated";
        param.Value = orderInfo.DateCreated;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        // The DateShipped parameter is sent only if data is available
        if (orderInfo.DateShipped.Trim() != "")
        {
            param = comm.CreateParameter();
            param.ParameterName = "@DateShipped";
            param.Value = orderInfo.DateShipped;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);
        }
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Verified";
        param.Value = orderInfo.Verified;
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Completed";
        param.Value = orderInfo.Completed;
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Canceled";
        param.Value = orderInfo.Canceled;
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Comments";
        param.Value = orderInfo.Comments;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CustomerName";
        param.Value = orderInfo.CustomerName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ShippingAddress";
        param.Value = orderInfo.ShippingAddress;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CustomerEmail";
        param.Value = orderInfo.CustomerEmail;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // return the results
        GenericDataAccess.ExecuteNonQuery(comm);
    }

    // Mark an order as verified
    public static void MarkVerified(string orderId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrderMarkVerified";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderID";
        param.Value = orderId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the results
        GenericDataAccess.ExecuteNonQuery(comm);
    }

    // Mark an order as completed
    public static void MarkCompleted(string orderId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrderMarkCompleted";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderID";
        param.Value = orderId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the results
        GenericDataAccess.ExecuteNonQuery(comm);
    }

    // Mark an order as canceled
    public static void MarkCanceled(string orderId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrderMarkCanceled";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderID";
        param.Value = orderId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the results
        GenericDataAccess.ExecuteNonQuery(comm);
    }


    //---------------------------用于数据字典-----------------------------------
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sysname"></param>
    /// <param name="itemname"></param>
    /// <param name="itemvalue"></param>
    /// <returns></returns>
    public static bool Diction_NewItem(string sysname, string itemname, string itemvalue)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Diction_NewItem";

        SqlParameter[] parms ={ 
            MakeInParam("@SysName",SqlDbType.VarChar,50,sysname),
            MakeInParam("@ItemName",SqlDbType.VarChar,500,itemname),
            MakeInParam("@ItemValue",SqlDbType.VarChar,50,itemvalue)
        };
        comm.Parameters.AddRange(parms);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch(Exception ex)
        {
            Utilities.Show(ex.Message);
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // Delete department
    public static bool Diction_DeleteItem(string id)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Diction_DeleteItem";

        //创建输入参数
        SqlParameter param = MakeInParam("@DicId", SqlDbType.Int, 0, id);
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            Utilities.Show(ex.Message);
        }
        return (result != -1);
    }

    public static bool Diction_UpdateItem(string id, string sysname, string itemname, string itemvalue)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Diction_UpdateItem";

        SqlParameter[] parms ={ 
            MakeInParam("@DicId",SqlDbType.Int,0,id),
            MakeInParam("@SysName",SqlDbType.VarChar,50,sysname),
            MakeInParam("@ItemName",SqlDbType.VarChar,50,itemname),
            MakeInParam("@ItemValue",SqlDbType.VarChar,50,itemvalue)
        };
        comm.Parameters.AddRange(parms);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            Utilities.Show(ex.Message);
        }
        // result will be 1 in case of success 
        return (result != -1);
    }
    
    //获得数据字典(用于存储过程，返回所有select)
    public static DataTable Diction_SelectAll()
    {
        DbCommand cmd = GenericDataAccess.CreateCommand();
        cmd.CommandText = "Diction_SelectAll";

        return GenericDataAccess.ExecuteSelectCommand(cmd);
    }

    public static DataTable Diction_SelectBySystem(string sysname)
    {
        DbCommand cmd = GenericDataAccess.CreateCommand();
        cmd.CommandText = "Diction_SelectBySysName";

        //创建输入参数
        SqlParameter param = MakeInParam("@SysName", SqlDbType.VarChar,50,sysname);
        cmd.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(cmd);
    }

    public static DataTable Diction_SelectSysName()
    {
        DbCommand cmd = GenericDataAccess.CreateCommand();
        cmd.CommandText = "Diction_SelectSysName";

        return GenericDataAccess.ExecuteSelectCommand(cmd);
    }    
    

    //------------------------------人员管理----------------------------------------
    public static bool Persons_NewItem(Person aPerson)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Persons_NewItem";

        SqlParameter[] parms ={ 
            MakeInParam("@UserName",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.UserName)),
            MakeInParam("@XingMing",SqlDbType.VarChar,50,aPerson.XingMing),
            MakeInParam("@Sex",SqlDbType.VarChar,2,Utilities.IsSQLNull(aPerson.Sex)),
            MakeInParam("@EnglishName",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.EnglishName)),
            MakeInParam("@UsedName_has",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.UsedName_has)),
            MakeInParam("@TelephoneNo",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.TelephoneNo)),
            MakeInParam("@fax",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.fax)),
            MakeInParam("@address",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.address)),
            MakeInParam("@mobilePhone",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.mobilePhone)),
            MakeInParam("@Email",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.Email)),
            MakeInParam("@QQ",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.QQ)),
            MakeInParam("@WeiXin",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.WeiXin)),
            MakeInParam("@ZhiWu",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.ZhiWu)),
            MakeInParam("@zhicheng",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.zhicheng)),
            MakeInParam("@ShenFenZhengNo",SqlDbType.VarChar,18,Utilities.IsSQLNull(aPerson.ShenFenZhengNo)),
            MakeInParam("@BirthDate",SqlDbType.Date,0,Utilities.IsSQLNull(aPerson.BirthDate)),
            MakeInParam("@MinZu",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.MinZu)),
            MakeInParam("@MaxHighXueWei",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.MaxHighXueWei)),
            MakeInParam("@ZhengZhiMianMiao",SqlDbType.VarChar,50,Utilities.IsSQLNull(aPerson.ZhengZhiMianMiao)),
            MakeInParam("@WorkTime_Init",SqlDbType.Date,0,Utilities.IsSQLNull(aPerson.WorkTime_Init)),
            MakeInParam("@DateComeWork",SqlDbType.Date,0,Utilities.IsSQLNull(aPerson.DateComeWork)),
            MakeInParam("@AiHao",SqlDbType.VarChar,1000,Utilities.IsSQLNull(aPerson.AiHao))           
        };
        comm.Parameters.AddRange(parms);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            Utilities.Show(ex.Message);
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // Delete department
    public static bool Persons_DeleteItem(string id)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Persons_DeleteItem";

        //创建输入参数
        SqlParameter param = MakeInParam("@PersonID", SqlDbType.Int, 0, id);
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            Utilities.Show(ex.Message);
        }
        return (result != -1);
    }

    public static bool Persons_UpdateItem(string id, string aXingMing, string aSex, 
                         string aMobilePhone,string aEmail)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Persons_UpdateItem";

        SqlParameter[] parms ={ 
            MakeInParam("@PersonID",SqlDbType.BigInt,0,id),
            MakeInParam("@XingMing",SqlDbType.VarChar,50,aXingMing),
            MakeInParam("@Sex",SqlDbType.VarChar,2,aSex),
            MakeInParam("@TelephoneNo",SqlDbType.VarChar,50,aMobilePhone),
            MakeInParam("@Email",SqlDbType.VarChar,50,aEmail)
        };

        comm.Parameters.AddRange(parms);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            Utilities.Show(ex.Message);
        }
        // result will be 1 in case of success 
        return (result != -1);
    }
    
    public static DataTable Person_SelectAll()
    {
        DbCommand cmd = GenericDataAccess.CreateCommand();
        cmd.CommandText = "Persons_SelectAll";

        return GenericDataAccess.ExecuteSelectCommand(cmd);
    }

    public static Person Persons_SelectById(int aID)
    {
        DbCommand cmd = GenericDataAccess.CreateCommand();
        cmd.CommandText = "Persons_SelectById";

        //创建输入参数
        SqlParameter param = MakeInParam("@PersonID", SqlDbType.BigInt,0, aID);
        cmd.Parameters.Add(param);

        DataTable aTable = GenericDataAccess.ExecuteSelectCommand(cmd);

        Person  details = new Person();
        if(aTable.Rows.Count > 0)
        {
            details.PersonID = Int32.Parse(aTable.Rows[0]["PersonID"].ToString());
            details.XingMing = aTable.Rows[0]["XingMing"].ToString();
            details.UserName = aTable.Rows[0]["UserName"].ToString();

        }       
        // return department details
        return details;
    }
    //------------------------------------人员管理结束------------------------------------------
    //------------------------------------部门管理------------------------------------------
    public static bool Department_NewItem(Department aDepartment)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "Department_NewItem";

        SqlParameter[] parms ={ 
            MakeInParam("@DepartmentName",SqlDbType.VarChar,50,Utilities.IsSQLNull(aDepartment.DepartmentName)),
            MakeInParam("@DepartmentPersonNo",SqlDbType.VarChar,50,Utilities.IsSQLNull(aDepartment.DepartmentPersonNo)),
            MakeInParam("@DepartmentPhone1",SqlDbType.VarChar,1000,Utilities.IsSQLNull(aDepartment.DepartmentPhone1)),
            MakeInParam("@DepartmentPhone2",SqlDbType.VarChar,50,Utilities.IsSQLNull(aDepartment.DepartmentPhone2)),
            MakeInParam("@DepartmentWork",SqlDbType.VarChar,50,Utilities.IsSQLNull(aDepartment.DepartmentWork)),
            MakeInParam("@DepartmentInfoFileNo",SqlDbType.VarChar,1000,Utilities.IsSQLNull(aDepartment.DepartmentInfoFileNo)),
            MakeInParam("@DepartmentNodeNo",SqlDbType.VarChar,1000,Utilities.IsSQLNull(aDepartment.DepartmentNodeNo))
        };
        comm.Parameters.AddRange(parms);

        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // Delete department部门删除
    public static bool Department_DeleteItem(string id)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "Department_DeleteItem";
        
        //创建输入参数
        SqlParameter param = MakeInParam("@DepartmentNo", SqlDbType.BigInt, 0, id);
        comm.Parameters.Add(param);
        
        // execute the stored procedure; an error will be thrown by the
        // database if the department has related categories, in which case
        // it is not deleted
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {

            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public static bool Department_UpdateItem(string id, string name, string aTelephone,string aDepartmentwork)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Department_UpdateItem";

        SqlParameter[] parms ={ 
            MakeInParam("@DepartmentNo",SqlDbType.BigInt,0,id),
            MakeInParam("@DepartmentName",SqlDbType.VarChar,50,Utilities.IsSQLNull(name)),
            MakeInParam("@DepartmentPhone1",SqlDbType.VarChar,50,Utilities.IsSQLNull(aTelephone)),
            MakeInParam("@DepartmentWork",SqlDbType.VarChar,1000,Utilities.IsSQLNull(aDepartmentwork))
        };
        comm.Parameters.AddRange(parms);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            Utilities.Show(ex.Message);
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    public static DataTable Department_SelectAll()
    {
        DbCommand cmd = GenericDataAccess.CreateCommand();
        cmd.CommandText = "Department_SelectAll";

        return GenericDataAccess.ExecuteSelectCommand(cmd);
    }




   
    
    // Update department details
    public static bool UpdateDepartment(string id, string name, string description)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogUpdateDepartment";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentId";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentDescription";
        param.Value = description;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    

    






       // Retrieve the list of departments 
    public static DataTable GetDepartments()
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetDepartments";
        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // get department details
    public static DepartmentDetails GetDepartmentDetails(string departmentId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetDepartmentDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // wrap retrieved data into a DepartmentDetails object
        DepartmentDetails details = new DepartmentDetails();
        if (table.Rows.Count > 0)
        {
            details.Name = table.Rows[0]["Name"].ToString();
            details.Description = table.Rows[0]["Description"].ToString();
        }
        // return department details
        return details;
    }

    // Get category details
    public static CategoryDetails GetCategoryDetails(string categoryId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetCategoryDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // wrap retrieved data into a CategoryDetails object
        CategoryDetails details = new CategoryDetails();
        if (table.Rows.Count > 0)
        {
            details.DepartmentId = Int32.Parse(table.Rows[0]["DepartmentID"].ToString());
            details.Name = table.Rows[0]["Name"].ToString();
            details.Description = table.Rows[0]["Description"].ToString();
        }
        // return department details
        return details;
    }

    // Get product details
    public static ProductDetails GetProductDetails(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // wrap retrieved data into a ProductDetails object
        ProductDetails details = new ProductDetails();
        if (table.Rows.Count > 0)
        {
            // get the first table row
            DataRow dr = table.Rows[0];
            // get product details
            details.ProductID = int.Parse(productId);
            details.Name = dr["Name"].ToString();
            details.Description = dr["Description"].ToString();
            details.Price = Decimal.Parse(dr["Price"].ToString());
            details.Thumbnail = dr["Thumbnail"].ToString();
            details.Image = dr["Image"].ToString();
            details.PromoFront = bool.Parse(dr["PromoFront"].ToString());
            details.PromoDept =
        bool.Parse(dr["PromoDept"].ToString());
        }
        // return department details
        return details;
    }

    // retrieve the list of categories in a department
    public static DataTable GetCategoriesInDepartment(string departmentId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetCategoriesInDepartment";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // Retrieve the list of products on catalog promotion
    public static DataTable GetProductsOnFrontPromo(string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductsOnFrontPromo";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse(comm.Parameters
      ["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)BalloonShopConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }

    // retrieve the list of products featured for a department
    public static DataTable GetProductsOnDeptPromo
    (string departmentId, string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductsOnDeptPromo";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                       (double)BalloonShopConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }

    // retrieve the list of products in a category
    public static DataTable GetProductsInCategory
    (string categoryId, string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductsInCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";

        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                       (double)BalloonShopConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }

    // Retrieve the list of product attributes 
    public static DataTable GetProductAttributes(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductAttributeValues";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // Search the product catalog
    public static DataTable Search(string searchString, string allWords,
    string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "SearchCatalog";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@AllWords";
        param.Value = allWords.ToUpper() == "TRUE" ? "1" : "0";
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyResults";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // define the maximum number of words
        int howManyWords = 5;
        // transform search string into array of words
        string[] words = Regex.Split(searchString, "[^a-zA-Z0-9]+");

        // add the words as stored procedure parameters
        int index = 1;
        for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
            // ignore short words
            if (words[i].Length > 2)
            {
                // create the @Word parameters
                param = comm.CreateParameter();
                param.ParameterName = "@Word" + index.ToString();
                param.Value = words[i];
                param.DbType = DbType.String;
                comm.Parameters.Add(param);
                index++;
            }

        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts =
      Int32.Parse(comm.Parameters["@HowManyResults"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                       (double)BalloonShopConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }

    

    // Create a new Category
    public static bool CreateCategory(string departmentId,
     string name, string description)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogCreateCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryDescription";
        param.Value = description;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }


    // Update category details
    public static bool UpdateCategory(string id, string name, string description)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogUpdateCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryId";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryDescription";
        param.Value = description;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }


    // Delete Category
    public static bool DeleteCategory(string id)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogDeleteCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryId";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure; an error will be thrown by the
        // database if the Category has related categories, in which case
        // it is not deleted
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    // retrieve the list of products in a category
    public static DataTable GetAllProductsInCategory(string categoryId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetAllProductsInCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    // Create a new product
    public static bool CreateProduct(string categoryId, string name, string description, string price, string Thumbnail, string Image, string PromoDept, string PromoFront)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogCreateProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductDescription";
        param.Value = description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Price";
        param.Value = price;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Thumbnail";
        param.Value = Thumbnail;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Image";
        param.Value = Image;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PromoDept";
        param.Value = PromoDept;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PromoFront";
        param.Value = PromoFront;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result >= 1);
    }

    // Update an existing product
    public static bool UpdateProduct(string productId, string name, string description, string price, string Thumbnail, string Image, string PromoDept, string PromoFront)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogUpdateProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductDescription";
        param.Value = description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Price";
        param.Value = price;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Thumbnail";
        param.Value = Thumbnail;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Image";
        param.Value = Image;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PromoDept";
        param.Value = PromoDept;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PromoFront";
        param.Value = PromoFront;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // get categories that contain a specified product
    public static DataTable GetCategoriesWithProduct(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetCategoriesWithProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // get categories that do not contain a specified product
    public static DataTable GetCategoriesWithoutProduct(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetCategoriesWithoutProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // assign a product to a new category
    public static bool AssignProductToCategory(string productId, string categoryId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogAssignProductToCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // move product to a new category
    public static bool MoveProductToCategory(string productId, string oldCategoryId,
     string newCategoryId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogMoveProductToCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";

        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@OldCategoryID";
        param.Value = oldCategoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@NewCategoryID";
        param.Value = newCategoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // removes a product from a category 
    public static bool RemoveProductFromCategory(string productId, string categoryId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogRemoveProductFromCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // deletes a product from the product catalog
    public static bool DeleteProduct(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogDeleteProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // gets product recommendations
    public static DataTable GetRecommendations(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductRecommendations";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // Gets the reviews for a specific product
    public static DataTable GetProductReviews(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductReviews";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // Add a new shopping cart item
    public static bool AddReview(string customerId, string productId, string review)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogAddProductReview ";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = customerId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Review";
        param.Value = review;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // returns true in case of success or false in case of an error
        try
        {
            // execute the stored procedure and return true if it executes
            // successfully, or false otherwise
            return (GenericDataAccess.ExecuteNonQuery(comm) != -1);
        }
        catch
        {
            // prevent the exception from propagating, but return false to
            // signal the error
            return false;
        }
    }
}
