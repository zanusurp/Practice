<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt"%>
<%@ include file="../../includes/header.jsp"%>

<div class="row">
	<div class="col-lg-12">
		<h1 class="page-header">Tables</h1>
	</div>
	<!-- /.col-lg-12 -->
</div>
<!-- /.row -->
<div class="row">
	<div class="col-lg-12">
		<div class="panel panel-default">
			<div class="panel-heading">Board List Page
				<button style="background-color: #d5f4e6;" id="regBtn" type="button" class="btn btn-xs pull-right">New Board</button>
			</div>
			<div class="panel-body">
				<table class="table table-striped table-bordered table-hover">
					<thead>
						<tr>
							<th>#번호</th>
							<th>제목</th>
							<th>작성자</th>
							<th>작성일</th>
							<th>수정일</th>
						</tr>
					</thead>
					<c:forEach items="${list }" var="board">
						<tr>
							<td><c:out value="${board.bno }"></c:out></td>
							<td><a href="/board/get?bno=${board.bno }">${board.title}</a></td>
							<td><c:out value="${board.writer}"></c:out></td>
							<td> <fmt:formatDate pattern="yyyy-MM-dd" value="${board.regdate }"/> </td>
							<td> <fmt:formatDate pattern="yyyy-MM-dd" value="${board.updateDate}"/> </td>
							
						</tr>
					</c:forEach>
				</table>
				<!-- Modal--------------------------------------------------- -->
				<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
					<div class="modal-dialog">
						<div class="modal-content">
							<div class="modal-header">
								<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
								<h4 class="modal-title" id="myModalLabel">확인</h4>
							</div>
							<div class="modal-body">처리가 완료 되었습니다</div>
							<div class="modal-footer">
								<button type="button" class="btn btn-default" data-dismiss="modal"> Close</button>
								<button type="button" class="btn btn-primary">Save changes</button>
							</div>
						</div>
					</div>
				</div>
				<!-- Modal -->
			</div>
		</div>
	</div>
</div>
			<!-- /.row -->
<script type="text/javascript">
	$(document).ready(function(){
		var result = '${result}';
		console.log(result);
		
		checkModal(result);
		
		history.replaceState({},null,null);
		
		function checkModal(result){
			if(result ==='' || history.state){
				return;
			}
				
			$('#myModal').modal("show");
		}
		
		$("#regBtn").on("click", function(){
			self.location = "/board/register";
		});
	});
	
</script>
			<%@ include file="../../includes/footer.jsp"%>