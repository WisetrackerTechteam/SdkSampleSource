import React from "react"
import Head from 'next/head'  
import { useRouter } from "next/router"; 

export default function ProductView() {
  	const router = useRouter(); 


	  React.useEffect(()=>{     
	  	if( typeof WDOT !== 'undefined' ){
	  		 /**
	  		  * 상품 상세 페이지에 대한 정보 전송  
	  		  ***/
		     WDOT.logScreen({
		          page_id : "productView.js"
		     });  
	 	}
	  },[]); 


	return (
	    <div className="container">
	      <Head>
	        <title>NextJs Example for website</title>
	        <link rel="icon" href="/favicon.ico" />
	      </Head>
	      <main>
	      	<h2>
	          상품 상세 페이지 입니다. 
	        </h2>


	        <button onClick={()=>{
	        	/**
	        	 * 장바구니 담기 이벤트 데이터 전송 
	        	 ***/
				WDOT.logEvent({
					event : "w_add_to_cart",
					product : {
						product_id : "2007291158",
						product_name : "Leia Pleats Bag Black",
						quantity : 2 
					}
				}); 						 
				alert('장바구니 담기 이벤트 데이터가 서버로 전송되었습니다.'); 
	        }}>상품을 장바구니 담기 이벤트</button> 



	        <button onClick={()=>{
	        	router.back();			
	        }}>메인 화면으로 이동</button> 
	      </main>
	    </div>
	); 
}
