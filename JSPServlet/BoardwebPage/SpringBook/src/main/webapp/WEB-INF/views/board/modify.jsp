<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ include file="../../includes/header.jsp" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>
<div class="row">
	<div class="col-lg-12">
		<h1 class="page-header">Board Register</h1>
	</div>
</div>

<div class="row">
	<div class="col-lg-12">
		<div class="panel panel-default">
			<div class="panel-heading">Board Read</div>
			<div class="panel-body">
				<form role="form" action="/board/modify" method="POST">
					<input type="hidden" name="pageNum" value='<c:out value="${cri.pageNum }" />' />
					<input type="hidden" name="amount" value='<c:out value="${cri.amount}" />' />
					<input type="hidden" name="type" value="${pageMaker.cri.type }" />
					<input type="hidden" name="keyword" value="${pageMaker.cri.keyword }" />
					<div class="form-group">
						<label>B.No</label>
						<input class="form-control" name="bno" value='<c:out value="${board.bno }" />'  readonly="readonly" />
					</div>
					<div class="form-group">
						<label>RegDate</label>
						<input class="form-control" name="regDate" value='<fmt:formatDate pattern='yyyy/MM/dd' value="${board.regdate }" />' readonly="readonly">
					</div>
					
					<div class="form-group">
						<label>writer</label>
						<input class="form-control" name="writer" value='<c:out value="${board.writer }" />' readonly="readonly" />
					</div>
					<div class="form-group">
						<label>Title</label> <input class="form-control" name="title"   value='<c:out value="${board.title}" />'>
					</div>
					<div class="form-group">
						<label>Text area</label>
						<textarea rows="3" class="form-control" name="content"   ><c:out value="${board.content }" ></c:out></textarea>
					</div>
					
					
					<!--  button ======================================================= -->
					<button type="submit" data-oper='modify' class="btn btn-default">Modify</button>
					<button type="submit" data-oper='remove' class="btn btn-danger">Remove</button>
					<button type="submit" data-oper='list' class="btn btn-info">List</button>
					
					<!--  button -->
				</form>
				
			</div>
		</div>
		
	</div>
</div>
<!-- 파일 수정 =================================================================== -->
<div class="bigPictureWrapper">
	<div class="bigPicture">
	</div>
</div>
<style>
	.uploadResult{
		width:100%;
		background-color: grey;
	}
	.uploadResult ul{
		display: flex;
		flex-flow: row;
		justify-content: center;
		align-items: center;
	}
	.uploadResult ul li{
		list-style: none !important;
		padding: 10px;
		align-content: center;
		text-align: center;
	}
	.uploadResult ul li img{
		widows: 100px;
	}
	.uploadResult ul li span{
		color: white;
	} 
	.bigPictureWrapper{
		position: absolute;
		display: none;
		justify-content: center;
		align-items: center;
		top: 0%;
		widows: 100%;
		height: 100%;
		background-color: gray;
		z-index: 100;
		background: rgba(255,255,255,0.5);
	}
	.bigPicture{
		position: relative;
		display: flex;
		justify-content: center;
		align-items: center;
	}
	.bigPicture img{
		width:600px;
	}
</style>


<div class="row">
	<div class="col-lg-12">
		<div class="panel panel-default">
			<div class="panel-heading">Files</div>
			<div class="panel-body">
				<div class="form-group uploadDiv">
					<input type="file" name="uploadFile" multiple="multiple">
				</div>
				<div class="uploadResult">
					<ul>
					</ul>
				</div>
			</div>
		</div>
	</div>

</div>
<!--  ======================================================== -->
<script type="text/javascript">
$(document).ready(function(){
	var formObj = $("form");
	
	$('button').on("click", function(e){
		e.preventDefault();
		var operation = $(this).data("oper");
		console.log(operation);
		
		if(operation === 'remove'){
			formObj.attr("action","/board/remove");
		}else if(operation === 'list'){
			//self.location="/board/list";
			formObj.attr("action","/board/list").attr("method","get");
			var pageNumTag = $("input[name='pageNum']").clone();
			var amountTag = $("input[name='amount']").clone();
			var keyboardTag = $("input[name='keyboard']").clone();
			var typeTag = $("input[name='type']").clone();
			
			formObj.empty();
			formObj.append(pageNumTag);
			formObj.append(amountTag);
			formObj.append(keyboardTag);
			formObj.append(typeTag);
			
			//아래것은 작동은 하는데 잘못됐음 비슷해서 남겨두도록 함 
			//formObj.attr("action","/board/list?pageNum="+${pageNum}+"&amount="+${amount}).attr("method","get");
		}else if(operation === 'modify'){
			console.log('submit clicked');
			var str = "";
			$(".uploadResult ul li").each(function(i, obj){
				var jobj = $(obj);
				console.dir("오브젝트 디렉토리: "+jobj);
				str += "<input type='hidden' name='attachList["+i+"].fileName' value='"+jobj.data("filename")+"' >";
				str += "<input type='hidden' name='attachList["+i+"].uuid' value='"+jobj.data("uuid")+"' >";
				str += "<input type='hidden' name='attachList["+i+"].uploadPath' value='"+jobj.data("path")+"' >";
				str += "<input type='hidden' name='attachList["+i+"].fileType' value='"+jobj.data("type")+"' >";
				
			});
			formObj.append(str).submit();
		}
		formObj.submit();
	});
	//파일
	(function(){
		var bno ='<c:out value="${board.bno}" />';
		$.getJSON("/board/getAttachList",{bno:bno}, function(arr){
			console.log("파일리스트  :  "+arr);
			var str = "";
			$(arr).each(function(i,attach){
				console.log(i+"번째 파일 타입 : "+attach.fileType);
				if(attach.fileType){
					var fileCallPath = encodeURIComponent(attach.uploadPath+"/s_"+attach.uuid+"_"+attach.fileName);
					console.log(i+"번째 파일 경로 :"+fileCallPath);
					str += "<li data-path='"+attach.uploadPath+"' data-uuid='"+attach.uuid+"' data-filename='"+attach.fileName+"' data-type='"+attach.fileType+"' ><div>";
					str += "<span>"+attach.fileName+"</span>";
					str += "<button type='button' data-file='"+fileCallPath+"' data-type='image' class='btn btn-warning btn-circle'>";
					str += "<i class='fa fa-times'></i></button><br/>";
					str += "<img src='/display?fileName="+fileCallPath+"' /></div></li>";
				}else{
					str += "<li data-path='"+attach.uploadPath+"' data-uuid='"+attach.uuid+"' data-filename='"+attach.fileName+"' data-type='"+attach.fileType+"' ><div>";
					str += "<span>"+attach.fileName+"</span><br />";
					str += "<button type='button' data-file='"+fileCallPath+"' data-type='image' class='btn btn-warning btn-circle'>";
					str += "<i class='fa fa-times'></i></button><br/>";
					str += "<img src='/resources/img/fileimg.png' /></div></li>";
				}
			});
			$(".uploadResult ul").html(str);
		});
	})();
	$(".uploadResult").on("click","button",function(e){
		console.log("delete file");
		$(this).closest("li").remove();
	});
	/// 파일 수정 업로드
	var regex = new RegExp("(.*?)\.(exe|sh|zip|alz|7z)$")
	var maxSize = 5242880;
	function checkExtension(fileName, fileSize){
		if(fileSize >= maxSize){
			alert("파일 사이즈 초과 5mb까지 가능");
			//document.querySelector("input[type='file']").value='';
			document.querySelector("input[type='file']").value=onreset;
			return false;
		}
		if(regex.test(fileName)){
			alert("실행이나 압 축 등 해당 종류의 파일은 업로드할 수 없습니다");
			return false;
		}
		return true;
		
	}
	$("input[type='file']").change(function(e){
		var formData = new FormData();
		var inputFile = $("input[name='uploadFile']");
		var files =  inputFile[0].files;
		console.log("파일 확인:"+files);
		console.log("파일 타입 확인:"+typeof(files));
		
		for(var i = 0; i< files.length;i++){
			if(!checkExtension(files[i].name, files[i].size)){
				return false;
			}
			console.log("파일이름"+files[i].name);
			
			formData.append("uploadFile",files[i]);
			console.log("전송까지 마무리 ");
		}
		
		$.ajax({
			url:'/uploadAjaxAction2',
			processData:false,
			contentType:false,
			data:formData,
			type:'POST',
			dataType:'json',
			success:function(result){
				console.log("성공 : "+result);
				showUploadResult(result);//섬네이창
			}
		}).done(function (data, textStatus, xhr) {
            console.log(xhr);
            if(data.result_cd == "1"){
                alert("success!");
            } else {
                //alert("에러발생["+data.result_cd+"]");// 이건 나중에 다시 참고하도록 해야 함 
                console.log(data.result_msg);
                
            }
        })
        .fail(function(data, textStatus, errorThrown){
            console.log("fail in get addr");
            console.log(data.result_msg);
            	console.log(textStatus);
        });
		console.log("아작스 실행까지 마무리");
		
	});
	//섬네일 창
	function showUploadResult(uploadResultArr){
		if(!uploadResultArr || uploadResultArr.length ==0 ){return;}
		var uploadUL = $(".uploadResult ul");
		var str = "";
		
		$(uploadResultArr).each(function(i,obj){
			console.log("파일 인덱스 : "+i+"파일 경로 : "+obj.uploadPath+"파일 이름 :"+obj.fileName);
			
			if(obj.image){
				var fileCallPath = encodeURIComponent(obj.uploadPath + "/s_"+obj.uuid+"_"+obj.fileName);
				str += "<li data-path='"+obj.uploadPath+"' data-uuid='"+obj.uuid+"' data-filename='"+obj.fileName+"' data-type='"+obj.image+"'";
				str += "><div>";
				str += "<span>"+obj.fileName+"</span>";
				str += "<button type='button' data-file=\'"+fileCallPath+"\'";
				str += " data-type='image' class='btn btn-warning btn-circle'><i class='fa fa-times'></i></button><br>";
				str += "<img src='/display?fileName="+fileCallPath+"'";
				str += "</div></li>";
			}else{
				var fileCallPath = encodeURIComponent(obj.uploadPath+"/"+obj.uuid+"_"+obj.fileName);
				var fileLink = fileCallPath.replace(new RegExp(/\\/g),"/");
				str += "<li data-path='"+obj.uploadPath+"' data-uuid='"+obj.uuid+"' data-filename='"+obj.fileName+"' data-type='"+obj.image+"' ><div>";
				str += "<span>"+obj.fileName+"</span>";
				str += "<button type='button' data-file=\'"+fileCallPath+"\' data-type='file' class='btn btn-warning btn-circle'><i class='fa fa-times'></i></button><br>"
				str += "<img src='/resources/img/fileimg.png'>";
				str += "</div></li>"
				
				
			}
		});
		uploadUL.append(str);
	}
});

</script>
<%@ include file="../../includes/footer.jsp" %>