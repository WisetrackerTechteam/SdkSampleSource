import React from "react"
import Head from 'next/head'  
import { useRouter } from "next/router"; 

export default function Purchase() {
  	const router = useRouter(); 



	  React.useEffect(()=>{     
	  	if( typeof WDOT !== 'undefined' ){

		  	  /**
		  	   * 구매 완료 페이지에 대한 분석 코드 적용 
		  	   * */		  		
		     WDOT.logScreen({
		          page_id : "purchase.js"
		     });  


			/**
			* 구매 완료에 대한 정보 데이터 전송 
			* */	
			WDOT.logPurchase({
				transaction_id : "TR2020111129420",
				currency : "KRW",
				product : {
					product_id : "2007291158",
					product_name : "Leia Pleats Bag Black",
					quantity : 1,
					revenue : 20000 
				}
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
	          결제 완료 페이지 입니다. 
	        </h2>

	        <button onClick={()=>{
	        	router.back();			
	        }}>메인 화면으로 이동</button> 
	      </main>
	    </div>
	); 
}
