<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<h1>회원 입력 폼</h1>
<form method="POST" action="connect02_preparedinsert.jsp">
	<table>
		<tr>
			<td>이름</td>
			<td><input type="text" name="name" size="20"></td>
		</tr>
		<tr>
			<td>아이디</td>
			<td><input type="text" name="userid" size="20"></td>
		</tr>
		<tr>
			<td>pass</td>
			<td><input type="text" name="pwd" size="20"></td>
		</tr>
		<tr>
			<td>email</td>
			<td><input type="text" name="email" size="20"></td>
		</tr>
		<tr>
			<td>phone</td>
			<td><input type="text" name="phone" size="20"></td>
		</tr>
		<tr>
			<td>grade</td>
			<td>
				<input type="radio" name="admin" value="1" checked="checked" /> 관리자
				<input type="radio" name="admin" value="0" /> 일반
			</td>
		</tr>
		<tr>
			<td><input type="submit" value="ok"></td>
			<td><input type="reset" value="cancel"></td>
		</tr>
		
	</table>
</form>
</body>
</html>