package com.test.controller;

import java.io.IOException;
import java.util.List;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.test.dao.ProductDAO;
import com.test.dto.ProductVO;


@WebServlet("/productList.do")
public class ProductListServlet extends HttpServlet {
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		ProductDAO pDao = ProductDAO.getInstance();
		List<ProductVO> productList = pDao.selectALlProducts();
		request.setAttribute("productList", productList);
		
		RequestDispatcher dispatcher = request.getRequestDispatcher("product/productList.jsp");
		dispatcher.forward(request, response);
	}


	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
