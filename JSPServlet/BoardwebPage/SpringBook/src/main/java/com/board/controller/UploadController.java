package com.board.controller;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.UUID;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.multipart.MultipartFile;

import lombok.extern.log4j.Log4j;

@Controller
@Log4j
public class UploadController {//스프링 레가시 mvc
	
	private String getFolder() {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
		Date date = new Date();
		
		String str = sdf.format(date);
		return str.replace("-", File.separator);
	}
	
	@GetMapping("/uploadForm")
	public void uploadForm() {
		log.info("업로드 폼 ");
	}
	@PostMapping("/uploadFormAction")
	public void uploadFormPost(MultipartFile[] uploadFile, Model model) {
		
		String uploadFolder = "c:\\upload";
		for(MultipartFile multipartFile : uploadFile) {
			log.info("옵로드중-----------------------------------------");
			log.info("uploadfile 이름 : "+multipartFile.getOriginalFilename());
			log.info("uploadfile 크기 : "+multipartFile.getSize());
			
			File saveFile = new File(uploadFolder,multipartFile.getOriginalFilename());
			
			try {
				multipartFile.transferTo(saveFile);
			} catch (Exception e) {
				// TODO: handle exception
				e.printStackTrace();
			}
		}
	}
	@GetMapping("/uploadAjax")
	public void uploadAjax() {
		log.info("upload ajax");
	}
	@PostMapping("/uploadAjaxAction")
	public void uploadAjaxPost(MultipartFile[] uploadFile) {
		log.info("upload ajax post.  . . . . ");
		String uploadFolder = "c:\\upload";
		//폴더형성
		File uploadPath = new File(uploadFolder, getFolder());
		log.info("업로드 경로 : "+uploadPath);
		
		if(uploadPath.exists()==false) {
			uploadPath.mkdirs();
		}
		
		for(MultipartFile multipartFile : uploadFile) {
			log.info("Update==================================================================");
			log.info("업로드 파일 이름"+multipartFile.getOriginalFilename());
			log.info("파일 사이즈 : "+multipartFile.getSize());
			String uploadFileName= multipartFile.getOriginalFilename();
			
			uploadFileName = uploadFileName.substring(uploadFileName.lastIndexOf("\\")+1);
			log.info("파일 이름만" +uploadFileName);
			
			UUID uuid = UUID.randomUUID();
			uploadFileName = uuid.toString() + "_" + uploadFileName;
			File saveFile = new File(uploadPath,uploadFileName);
			try {
				multipartFile.transferTo(saveFile);
			} catch (Exception e) {
				log.error(e.getMessage());
			}
			
		}
		
	}
}
