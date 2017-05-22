function selectall(v){ 
var f=document.forms["listform"]; //listform
for (i=0;i<f.elements.length;i++) 
if (f.elements[i].name=="listform") //ids
f.elements[i].checked=v; 
}