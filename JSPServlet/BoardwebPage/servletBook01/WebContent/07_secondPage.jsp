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
<c:out value="helo!!"></c:out>

두번째 페이지 <br>
<hr>
페이지 속성: <%= pageContext.getAttribute("name") %> <br>
요청 속성:<%= request.getAttribute("name") %> <br>
세선 속성:<%= session.getAttribute("name") %> <br>
어플 속성:<%= application.getAttribute("name") %> <br>

<a href="07_thirdPage.jsp" >다음 페이지로 </a>

</body>
</html>