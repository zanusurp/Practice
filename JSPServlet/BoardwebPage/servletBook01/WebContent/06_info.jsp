<%@page import="java.text.SimpleDateFormat"%>
<%@page import="java.util.Calendar"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<h3>get 방식 한글 꺠짐 방지</h3>
<form method="get" action="InfoServlet">
	이름:<input type="text" name="name" />
	주소:<input type="text" name="addr" />
	<input type="submit" value="전송" />
</form>
<br>
<h3>post 방식 한글 꺠짐 방지</h3>
<form method="post" action="InfoServlet">
	이름:<input type="text" name="name" />
	주소:<input type="text" name="addr" />
	<input type="submit" value="전송" />
</form>
<%
	Calendar date = Calendar.getInstance();
	SimpleDateFormat today = new SimpleDateFormat("yyyy년 MM월 dd일");
	SimpleDateFormat now = new SimpleDateFormat("hh:mm:ss");
%>
<br>
<b><%= today.format(date.getTime()) %></b><br>
<b><%= now.format(date.getTime()) %></b><br>




</body>
</html>