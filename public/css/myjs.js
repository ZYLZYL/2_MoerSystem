<!--
//�ı䵱ǰ����ɫ
var orObj;
var orBg;
function changeBg(obj){
if(orObj){
orObj.style.backgroundColor=orBg;
}
orObj = obj;
orBg = obj.style.backgroundColor;
obj.style.backgroundColor='#FCFAC8';
}

//����ȫѡ/ȫ��ѡ
function chkAll()
    {
    var chkall= document.all["chkall"];
    var chkother= document.getElementsByTagName("input");
    for (var i=0;i<chkother.length;i++)
        {
        if( chkother[i].type=='checkbox')
            {
                if(chkother[i].id.indexOf('GridView1')>-1)
                {
                    if(chkall.checked==true)
                    {
                    chkother[i].checked=true;
                    }
                    else
                    {
                    chkother[i].checked=false;
                    }
                }
            }
        }
    }

//ȫѡ��ȡ����ѡ��
function CheckAll(form)
  {
  for (var k=0;k<form.elements.length;k++)
    {
    var e = form.elements[k];
    //�жϲ���ѡ����
    if (e.name != 'chkall'){
       //�ж�ѡ���� �߼����� 
       if (e.name != 'gjjs'){
       //�ж�ѡ���� �������� 
         if (e.name != 'gltj'){
       e.checked = form.chkall.checked;
         }
       }
    }
    }
}

//ɾ��ǰȷ��
function check(objName){
var   o=document.getElementsByName(objName)
for(i=0;i<o.length;i++)if(o[i].checked)return;
alert("����ѡ����ɾ����");

location.reload();
}

//ˢ�°�ť
  function reload()   
  {   
  var   name=navigator.appName   
  var   vers=navigator.appVersion   
  if(name=='Netscape'){   
  window.location.reload(true)   
  }   
  else{   
  history.go(0)   
  }   
  }

//��λ��ϸ��������
function openwin(src)
 {
  var vDialog=null;
  vDialog=showModalDialog(src,window,"status:no;scrollbars:no;resizable:off;dialogHeight:750px;dialogWidth:1000px;unadorne:yes;help:no");
  }
  
//��λ��ϸ����С����
function openwin_s(src)
 {
  var vDialog=null;
  vDialog=showModalDialog(src,window,"status:no;resizable:off;dialogHeight:400px;dialogWidth:550px;unadorne:yes;help:no");
  }
  
//����������������
var X = 250; // x position
var Y = 250; // y position
var W = 650; // width
var H = 360; // height
var s="resizable=no,left="+X+",top="+Y+",screenX="+X+",screenY="+Y+",width="+W+",height="+H; // Do not edit below this line.
function popZdy(U){
var SGW = window.open(U,'TheWindow',s)
}

//���Excel�������ڣ�����Ϊ����A4ֽ
function popOut(Q){
window.open (Q,'newwindow1','height=550,width=750,top='+(screen.height-550)/2+',left='+(screen.width-750)/2+',toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no') 
}

//�������Ӵ��ڣ���ֹ��������
function popAdd(V){
window.open (V,'newwindow6','height=550,width=750,top='+(screen.height-550)/2+',left='+(screen.width-750)/2+',toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no') 
}

//�������Ӵ��ڣ��ſ���������
function popAdd2(X){
window.open (X,'newwindow2','height=550,width=750,top='+(screen.height-550)/2+',left='+(screen.width-750)/2+',toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=no') 
}

//�����޸Ĵ���
function popMod(W){
window.open (W,'newwindow3','height=550,width=750,top='+(screen.height-550)/2+',left='+(screen.width-750)/2+',toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no')
}

//��ӡԤ�����ڣ�����Ϊ����A4ֽ
function popPrn(U){
window.open (U,'newwindow4','height=550,width=750,top='+(screen.height-550)/2+',left='+(screen.width-750)/2+',toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no') 
}

//���ͼ���������ڣ�����Ϊ����A4ֽ
function popChart(P){
window.open (P,'newwindow5','height=550,width=800,top='+(screen.height-550)/2+',left='+(screen.width-800)/2+',toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no') 
}

//ע��ҳ��
function popReg(Y){
window.open (Y,'newwindow7','height=300,width=450,top='+(screen.height-300)/2+',left='+(screen.width-450)/2+',toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no') 
}

//�������Ϣ����
function MiniX(U){
var MSGW = window.open(U,'TheWindow','resizable=no,scrollbars=no,top='+(screen.height-260)/2+',left='+(screen.width-350)/2+',width=350,height=260')
}

//�ʵݱ�ǩ��ӡ����
function popYdbq(G){
window.open (G,'ydbqwindow','height=500,width=400,top='+(screen.height-500)/2+',left='+(screen.width-400)/2+',toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=no') 
}

//��ѡ�û���������
function selyh() 
	{
    window.open("/choose/selyh.aspx",null,'height=300,width=450,top='+(screen.height-300)/2+',left='+(screen.width-450)/2+',directories = no,status=no,toolbar=no,menubar=no,location=no,titlebar = no,scrollbars = no');
    }

//��ѡ��Ա��������
function selhy() 
	{
    window.open("/choose/selhy.aspx",null,'height=300,width=450,top='+(screen.height-300)/2+',left='+(screen.width-450)/2+',directories = no,status=no,toolbar=no,menubar=no,location=no,titlebar = no,scrollbars = no');
    }

//���������޸Ĵ���
function popMiniMod(J){
window.open (J,'newwindowJ','height=400,width=650,top='+(screen.height-400)/2+',left='+(screen.width-650)/2+',toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no')
}

/*ҳ����Ҷ�λ��ʼ*/
/*ҳ����Ҷ�λ����*/

//-->