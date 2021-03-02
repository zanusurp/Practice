package com.test.controller;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.test.dao.MemberDAO;
import com.test.dto.MemberVO;


@WebServlet("/login.do")
public class LoginServlet extends HttpServlet {

   
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String url  = "member/login.jsp";
		HttpSession session = request.getSession();
		if(session.getAttribute("loginUser")!=null) {
			url="member/main.jsp";
		}
		RequestDispatcher dispatcher = request.getRequestDispatcher(url);
		dispatcher.forward(request, response);
	}

	
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		System.out.println("포스트에 옴 ");
		String url = "member/login.jsp";
		
		String userid = request.getParameter("userid");
		String pwd = request.getParameter("pwd");
		
		MemberDAO mDao = MemberDAO.getInstance();
		int result = mDao.userCheck(userid, pwd);
		System.out.println(result);
		if(result ==1) {
			MemberVO mVo = mDao.getMember(userid);
			HttpSession session = request.getSession();
			session.setAttribute("loginUser", mVo);
			request.setAttribute("message", "회원 가입에 성공");
			url = "member/main.jsp";
		}else if( result ==0) {
			request.setAttribute("message", "Pasword is not correct");
		}else if(result ==-1) {
			request.setAttribute("message", "User does not exist");
		}
		RequestDispatcher dispatcher = request.getRequestDispatcher(url);
		dispatcher.forward(request, response);
	}

}
