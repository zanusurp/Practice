package com.book.controller;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;

import org.springframework.beans.propertyeditors.CustomDateEditor;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.WebDataBinder;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.InitBinder;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;

import com.book.domain.SampleDTO;
import com.book.domain.SampleDTOList;
import com.book.domain.TodoDTO;

import lombok.extern.log4j.Log4j;

@Controller
@RequestMapping("/Sample/*")
@Log4j
public class SampleController {

	@InitBinder
	public void initBinder(WebDataBinder binder) {
		SimpleDateFormat dataFormat = new SimpleDateFormat("yyyy-MM-dd");
		binder.registerCustomEditor(java.util.Date.class, new CustomDateEditor(dataFormat, false));
	}
	@RequestMapping(value = "/basic", method = {RequestMethod.GET,RequestMethod.POST})
	public void basicGet() {
		log.info("basic------------------------------------------------");
	}
	@RequestMapping("/basicOnlyGet")
	public void basicGet2() {
		log.info("basic only get -------------------------------------------------------");
	}
	@GetMapping("/ex01")
	public String ex01(SampleDTO dto) {
		log.info(""+dto);
		return "ex01";
	}
	@GetMapping("/ex02")
	public String ex02(@RequestParam("name") String name, @RequestParam("age") int age) {
		log.info("name para : "+name);
		log.info("age param : "+age);
		return "ex02";
	}
	@GetMapping("/ex02List")
	public String ex02List(@RequestParam("ids") ArrayList<String> ids) {
		log.info("Param ids : "+ ids);
		return "ex02List";
		
	}
	@GetMapping("/ex02Array")
	public String ex02Array(@RequestParam("ids") String[] ids) {
		log.info("array ids : "+ Arrays.deepToString(ids));
		log.info("array ids : "+ ids);
		return "ex02Array";
	}
	@GetMapping("/ex02Bean")
	public String ex02Bean(SampleDTOList list) {
		log.info("list sample DTO List : "+list);
		return "ex02Bean";
	}
	@GetMapping("/ex03")
	public String ex03(TodoDTO todo) {
		log.info("todo Simpleformat : "+todo);
		return "ex03";
	}
	@GetMapping("/ex04")
	public String ex04(SampleDTO dto, @ModelAttribute("page") int page) {
		log.info("DTO : " + dto);
		log.info("page :  "+page);
		return "/ex04";
	}
	@GetMapping("/ex06")
	public @ResponseBody SampleDTO ex06() {
		log.info("-----------/ex06---------------");
		SampleDTO dto = new SampleDTO();
		dto.setAge(20);
		dto.setName("È«°¥µ¿");
		
		return dto;
	}
	@GetMapping("/ex07")
	public ResponseEntity<String> ex07(){
		log.info("===============07 ex");
		String msg = "{\" name\": \"È«±æµ¿\"}";
		HttpHeaders header = new HttpHeaders();
		header.add("Content-Type", "application/json;charset=UTF-8");
		
		return new ResponseEntity<>(msg,header,HttpStatus.OK);
		
	}
	@GetMapping("/exUpload")
	public String exUpload() {
		log.info("/exUpload========================================");
		return "/exUpload";
		
	}
	@PostMapping("/exUploadPost")
	public String exUploadPost(ArrayList<MultipartFile> files) {
		files.forEach(file->{
			log.info("====================================");
			log.info("name : " + file.getOriginalFilename());
			log.info("size : "+file.getSize());
			
		});
		return "/exUploadPost";
	}
}
