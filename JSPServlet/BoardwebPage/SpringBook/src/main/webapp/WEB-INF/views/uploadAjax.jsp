<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<style type="text/css">
	.uploadResult{
	width:100%;
	background-color:gray;
	}
	.uploadResult ul{
		display:flex;
		flex-flow:row;
		justify-content:center;
		align-items:center;
	}
	.uploadResult ul li{
		list-style:none;
		padding:10px;
	}
	
</style>

</head>
<body>
<h1>upload with ajasx</h1>
<div class="uploadDiv">
	<input type="file" name="uploadFile" multiple  />
</div>
<button id="uploadbtn">Upload</button>

<div class="uploadResult">
	<ul>
	</ul>
</div>

<!-- <script src="/resources/vendor/jquery/jquery.min.js"></script> -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script> 
<script type="text/javascript">
/* window.onload = function(){
	var btn  = document.getElementById('uploadbtn');
	btn.addEventListener('click',function(event){
		event.preventDefault();
		var xhr = new XMLHttpRequest();
		xhr.open('post','/uploadAjaxAction2',true);
		//xhr.setRequestHeader('Content-Type','false');
		var data = new FormData();
		var inputfile = document.querySelector("input");
		var files = inputfile.files;
		console.log("목록 갯수 좀 봅시다 : "+files.length);
		for(var i =0; i<files.length; i++){
			file = files.item(i);
			alert(file.name);
			data.append('uploadFile',file);
		}
		
		
		//data.append("uploadFile",files);
		//그냥 확인용 
		for(var i = 0; i< files.length; i++){
			var file  = files.item(i);
			
			console.log(file);
			
		}
		//xhr.setRequestHeader("Content-Type", "text/html;charset=utf-8");
		 //xhr.onload = function(){
			//if(this.status >= 200 && this.status < 400){
				//console.log(this.response)
			//}else{
			//	console.log(this.response)
		//	}
			
		//} 
		// 안넣어도 알아서 헤더 적용 함 
		//xhr.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		//xhr.setRequestHeader("Content-Type","multipart/form-data");
		//xhr.setRequestHeader("processData",false);
		//xhr.setRequestHeader("enctype","multipart/form-data");
		xhr.send(data);
	});
	
}        */


 $( document ).ready(function(){
	//업로드 부문
		var uploadresult = $(".uploadResult ul");
		function showUploadedFile(uploadResultArr){
			var str = "";
			$(uploadResultArr).each(function(i, obj){
				console.log("오베젵트 : "+obj);
				console.log("파일이름 : "+obj.fileName);
				console.log("파일이름 : "+obj.name);
				console.log("타입 "+typeof(obj));
				if(obj.image){
					str+="<li><img src='/resources/img/fileimg.png' />"+obj.fileName +"</li>";	
				}else{
					//str += "<li>"+obj.fileName + "</li>";
					var fileCallPath = encodeURIComponent(obj.uploadPath+"/s_"+obj.uuid+"_"+obj.fileName);
					str += "<li><img src='/display?fileName="+fileCallPath+"'</li>"
				}
			});
			
			uploadresult.append(str);
		}
		var cloneObj = $('.uploadDiv').clone();
		
		$("#uploadbtn").on("click",function(e){
			var formData = new FormData();
			var inputFile = $("input[name='uploadFile']");
			var files = inputFile[0].files;
			
			console.log(files);
			
			for(var i = 0; i< files.length; i++){
				formData.append("uploadFile",files[i]);
			}
			 $.ajax({
				//url:'/uploadAjaxAction',
				url:'/uploadAjaxAction2',
				processData:false,
				contentType:false,
				data:formData,
				dataType:'json',
				type:'POST',
				success:function(result){
					alert(result);
					showUploadedFile(result);
					$('.uploadDiv').html(cloneObj.html());
				}
			}); 
		});
		
		
	});   
  
  
</script>


</body>


</html>