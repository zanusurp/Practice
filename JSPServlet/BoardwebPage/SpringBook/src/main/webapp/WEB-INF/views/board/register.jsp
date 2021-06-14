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
			<div class="panel-heading">Board Register</div>
			<div class="panel-body">
				<form role="form" action="/board/register" method="POST">
					<div class="form-group">
						<label>Title</label> <input class="form-control" name="title">
					</div>
					<div class="form-group">
						<label>Text area</label>
						<textarea rows="3" class="form-control" name="content" ></textarea>
					</div>
					<div class="form-group">
						<label>Writer</label> <input class="form-control" name="writer">
					</div>
					<button type="submit" class="btn btn-default" >Submit Button</button>
					<button type="reset" class="btn btn-default">Reset Button</button>
				</form>
			</div>
		</div>
		<!-- 파일 첨부 -->
		<div class="row">
			<div class="col-lg-12">
				<div class="panel panel-default">
					<div class="panel-heading">파일 첨부</div>
					<div class="panel-body">
						<input type="file" name="uploadFile" multiple>
					</div>
					<div class="uploadResult">
						<ul>
						
						</ul>
					</div>
				</div>
			</div>
		</div>
		
	</div>
</div>
<<script type="text/javascript">
	$(function(e){
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
		//삭제 이벤트
		$(".uploadResult").on("click","button",function(e){
			/* console.log("이것 :  "+this);
			console.log("이것 문자:  "+this.toString());
			console.log("이것타입 :  "+typeof(this));
			 */
			
			console.log("delete file");
			var targetFile = $(this).data("file"); //버근가.. 
			//var targetFile  = this.document.querySelector("input[type='file']").files;
			console.log("대상 파일 : "+targetFile);
			//
			var type = $(this).data("type");
			console.log("대상 타입 : "+type);
			//
			var targetLi = $(this).closest("li");
			console.log("선택된 lio :"+targetLi);
			$.ajax({
				url:'/deleteFile',
				data:{fileName:targetFile, type:type},
				dataType:'text',
				type:'POST',
				success:function(result){
					alert(result);
					targetLi.remove();
				}
			})
		});
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
		
		
		
		
		
		var formObj = $("form[role='form']");
		$("button[type='submit']").on("click",function(e){
			e.preventDefault();
			console.log("게시글 폼 서밋 실행");
			var title = document.querySelector("input[name='title']").value;
			var writer = document.querySelector("input[name='writer']").value;
			var content = document.querySelector("textarea[name='content']").value;
			if(title.value == "" || writer.value == "" || content.value == "" ||title.length<= 0 || writer.length <= 0 || content.length <= 0){
				alert("글쓴이 ,글내용 ,글제목 중 하나라도 빠져있으면 작성 되지 않습니다. ");
				return false;
			}
			
			var str = "";
			$(".uploadResult ul li").each(function(i,obj){
				var jobj = $(obj);
				console.dir(jobj);
				console.log("jobj 표시 : "+jobj);
				str += "<input type='hidden' name='attachList["+i+"].fileName' value='"+jobj.data("filename")+"'>";
				str += "<input type='hidden' name='attachList["+i+"].uuid' value='"+jobj.data("uuid")+"'>";
				str += "<input type='hidden' name='attachList["+i+"].uploadPath' value='"+jobj.data("path")+"'>";
				str += "<input type='hidden' name='attachList["+i+"].fileType' value='"+jobj.data("type")+"'>";
				
			})
			formObj.append(str).submit();
			
		});
	});
</script>
<%@ include file="../../includes/footer.jsp" %>