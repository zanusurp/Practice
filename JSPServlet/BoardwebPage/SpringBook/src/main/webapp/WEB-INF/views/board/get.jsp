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
					
					<div class="form-group">
						<label>B.No</label>
						<input class="form-control" name="bno" value='<c:out value="${board.bno }" />' readonly="readonly" />
					</div>
					<div class="form-group">
						<label>writer</label>
						<input class="form-control" name="writer" value='<c:out value="${board.writer }" />' readonly="readonly" />
					</div>
					<div class="form-group">
						<label>Title</label> <input class="form-control" name="title" readonly="readonly" value='<c:out value="${board.title}" />'>
					</div>
					<div class="form-group">
						<label>Text area</label>
						<textarea rows="3" class="form-control" name="content" readonly="readonly" ><c:out value="${board.content }" ></c:out></textarea>
					</div>
					
					
					
					
					<%-- <button class="btn btn-default" data-oper="modify" onclick="location.href='/board/modify?bno=<c:out value="${board.bno }" />'">Modify</button>
					<button class="btn btn-info" data-oper="list" onclick="location.href='/board/list'" >List</button> --%>
					<button class="btn btn-default" data-oper="modify" >Modify</button>
					<button class="btn btn-info" data-oper="list" >List</button>
					
					<form id="operForm" action="/board/modify" method="get">
						<input type="hidden" id="bno" name="bno" value='<c:out value="${board.bno }" />' />
						<input type="hidden" name="pageNum" value='<c:out value="${cri.pageNum }" />' />
						<input type="hidden" name="amount" value='<c:out value="${cri.amount }" />' />
					</form>
					
			</div>
		</div>
		
	</div>
</div>
<script type="text/javascript">
	$(document).ready(function(){
		var operForm = $("#operForm");
		$("button[data-oper='modify']").on("click",function(e){
			operForm.attr("action","/board/modify").submit();
		});
		$("button[data-oper='list']").on("click",function(e){
			//operForm.attr("action","/board/list").submit();
			operForm.find("#bno").remove();
			operForm.attr("action","/board/list");
			operForm.submit();
		});
	});
</script>


<%@ include file="../../includes/footer.jsp" %>