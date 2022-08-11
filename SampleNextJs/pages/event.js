import React from "react"
import Head from 'next/head'  
import { useRouter } from "next/router"; 


export default function Event() { 
  	const router = useRouter(); 

	  React.useEffect(()=>{     
	  	if( typeof WDOT !== 'undefined' ){
	  		 /**
	  		  * 이벤트 페이지에 대한 정보 전송 
	  		  ***/
		     WDOT.logScreen({
		          page_id : "event.js"
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
	          이벤트 페이지 입니다. 
	        </h2>
	        <button onClick={()=>{
	        	router.back();			
	        }}>메인 화면으로 이동</button> 
	      </main>
	    </div>
	);

}
