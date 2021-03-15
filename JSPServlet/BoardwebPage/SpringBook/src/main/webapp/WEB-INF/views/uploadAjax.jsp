<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<h1>upload with ajasx</h1>
<div class="uploadDiv">
	<input type="file" name="uploadFile" multiple />
</div>
<button id="uploadbtn">Upload</button>
</body>

<!-- <script src="/resources/vendor/jquery/jquery.min.js"></script> -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script> 
<script type="text/javascript">
/* window.onload = function(){
	var btn  = document.getElementById('uploadbtn');
	btn.addEventListener('click',function(event){
		event.preventDefault();
		var xhr = new XMLHttpRequest();
		xhr.open('post','/uploadAjaxAction',true);
		//xhr.setRequestHeader('Content-Type','false');
		var data = new FormData();
		var inputfile = document.querySelector("input");
		var files = inputfile.files;
		console.log(files);
		data.append("uploadFile",files);
		//그냥 확인용 
		for(var i = 0; i< files.length; i++){
			var file  = files.item(i);
			
			console.log(file);
			
		}
		//xhr.setRequestHeader("Content-Type", "text/html;charset=utf-8");
		xhr.onload = function(){
			if(this.status >= 200 && this.status < 400){
				console.log(this.response)
			}else{
				console.log(this.response)
			}
			
		}
		//xhr.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		//xhr.setRequestHeader("Content-Type","multipart/form-data");
		//xhr.setRequestHeader("processData",false);
		//xhr.setRequestHeader("enctype","multipart/form-data");
		xhr.send(data);
	});
	
	
}      */


 $( document ).ready(function(){
		$("#uploadbtn").on("click",function(e){
			var formData = new FormData();
			var inputFile = $("input[name='uploadFile']");
			var files = inputFile[0].files;
			
			console.log(files);
			
			for(var i = 0; i< files.length; i++){
				formData.append("uploadFile",files[i]);
			}
			 $.ajax({
				url:'/uploadAjaxAction',
				processData:false,
				contentType:false,
				data:formData,
				type:'POST',
				success:function(result){
					alert("uploaded");
				}
			}); 
		});
	});   
  
 
</script>

</html>