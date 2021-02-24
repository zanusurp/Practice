<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
세번째 페이지 <br>
<hr>
페이지 속성: <%= pageContext.getAttribute("name") %> <br>
요청 속성:<%= request.getAttribute("name") %> <br>
세선 속성:<%= session.getAttribute("name") %> <br>
어플 속성:<%= application.getAttribute("name") %> <br>

</body>
</html>