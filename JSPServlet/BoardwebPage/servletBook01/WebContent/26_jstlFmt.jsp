<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>
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
<c:set var="now" value="<%= new java.util.Date() %>"> </c:set>
<fmt:formatDate value="${now }"/><br>
<fmt:formatDate value="${now }" type="date"/><br>
<fmt:formatDate value="${now }" type="both"/><br>
<fmt:formatDate value="${now }" type="time"/><br>
<fmt:formatDate value="${now }" pattern="yyyy년 mm월 dd일  hh:MM:ss"/><br>

<br>
타임존
<br>
<jsp:useBean id="now2" class="java.util.Date"></jsp:useBean>
<pre>
default: <c:out value="${now2 }"></c:out><br><br>
Korea KST : <fmt:formatDate value="${now2 }" type="both" dateStyle="full" timeStyle="full" />
<br>
<fmt:timeZone value="GMT">
Swiss GMT	: <fmt:formatDate value="${now2 }" type="both" dateStyle="full" timeStyle="full"/>
</fmt:timeZone><br>

<fmt:timeZone value="GMT-8">
Swiss GMT	: <fmt:formatDate value="${now2 }" type="both" dateStyle="full" timeStyle="full"/>
</fmt:timeZone><br>

</pre>

</body>
</html>