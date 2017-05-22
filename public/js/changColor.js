//当鼠标移动到上边的时候改变颜色
function changColor(obj){


obj.style.backgroundColor='#6D98FB';
//obj.style.fontSize=18+'px';
}
//当鼠标移出时候改变颜色
function changColor2(obj){
if(obj.style.backgroundColor="#6D98FB"){
obj.style.backgroundColor="";
//obj.style.fontSize=12+'px';
}else{
obj.style.backgroundColor="#6D98FB";
}
}
//点击checkbox改变颜色
function changColor3(obj){
	
obj.style.backgroundColor="#6D98FB";
}
function changColor4(obj){
if(obj.style.backgroundColor="#6D98FB"){
obj.style.backgroundColor="";
}else{
obj.style.backgroundColor="#6D98FB";
}
}

function change(fa,ch){
	 if(ch.checked){
		changColor3(fa);
		}else{
			changColor4(fa);
		}
	}

//判断鼠标移到上边是否变色
function change2(fa){
		changColor(fa);
	}
function change3(fa){
	if (!(fa.cells[fa.cells.length-1].getElementsByTagName("input")[0].checked)){  
		changColor2(fa);		
		}else{
		}
	}
//全选反选颜色显示
function change4(fa){
	if(fa.checked){
	var allFa=fa.parentNode.parentNode.parentNode;
	alert(allFa);
	for (var i=1;i<allFa.rows.length;i++){
		allFa.rows[i].style.backgroundColor="#6D98FB";;
			}
		}else{
			}
	}
	
(function(){
	var oTable=document.getElementById("alternatecolor");
	
	for (var i=1;i<oTable.rows.length;i++){
		var num=oTable.rows[i].cells.length;
		var inp=oTable.rows[i].cells[num-1].getElementsByTagName("input")[0];
		
		inp.setAttribute("onclick", "change(this.parentNode.parentNode,this)");
      oTable.rows[i].setAttribute("onmouseover", "change2(this)");
	  oTable.rows[i].setAttribute("onmouseout", "change3(this)");
	  
   }   
   
		var num1=oTable.rows[0].cells.length;
		var inp1=oTable.rows[0].cells[num-1].getElementsByTagName("input")[0];
		inp1.addEventListener("click", function(){
			
		if(inp1.checked){
			
				for (var i=1;i<oTable.rows.length;i++){
					oTable.rows[i].style.backgroundColor="#6D98FB";}
		}else{
			
			for (var i=1;i<oTable.rows.length;i++){
				oTable.rows[i].style.backgroundColor="";}
		}
});
     
}());
