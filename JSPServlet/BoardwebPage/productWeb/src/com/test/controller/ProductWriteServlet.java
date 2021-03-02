package com.test.controller;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.oreilly.servlet.MultipartRequest;
import com.oreilly.servlet.multipart.DefaultFileRenamePolicy;
import com.test.dao.ProductDAO;
import com.test.dto.ProductVO;

import util.DBManager;


@WebServlet("/productWrite.do")
public class ProductWriteServlet extends HttpServlet {
	
   @Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
	   RequestDispatcher dispatcher = req.getRequestDispatcher("product/productWrite.jsp");
	   dispatcher.forward(req, resp);
	
	}
	
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		request.setCharacterEncoding("UTF-8");
		ServletContext context = getServletContext();
		String path = context.getRealPath("upload");
		String encType = "UTF-8";
		int sizeLimit = 20*1024*1024;
		System.out.println("글쓰는데 이미지 위치 : "+ path);
		MultipartRequest multi = new MultipartRequest(request, path, sizeLimit, encType, new DefaultFileRenamePolicy());
		
		String name  = multi.getParameter("name");
		int price = Integer.parseInt(multi.getParameter("price"));
		String description = multi.getParameter("description");
		String pictureurl = multi.getFilesystemName("pictureurl");
		ProductVO pVo  = new ProductVO();
		pVo.setName(name);
		pVo.setPrice(price);
		pVo.setDescription(description);
		pVo.setPictureUrl(pictureurl);
		
		ProductDAO pDao = ProductDAO.getInstance();
		pDao.insertProduct(pVo);
		
		response.sendRedirect("productList.do");
		
	}

}
