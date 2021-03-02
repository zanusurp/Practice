<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

<c:set var="age" value="30" scope="page" ></c:set>
나이 : <c:out value="${age }">10</c:out><br>

<br>
나이 지우고 
<br>
<c:remove var="age" scope="page"/>
나이 : <c:out value="${age }">10</c:out><br>

<c:catch var="errmsg">
	예외 발생 전<br>
	<%= 1/0 %><br>
	에외 발생 후<br>
</c:catch>
<c:out value="나오는 에러메세지 ${errmsg }"></c:out>

</body>
</html>