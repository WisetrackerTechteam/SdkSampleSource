import React from "react"
import Head from 'next/head'  
import { useRouter } from "next/router"; 


export default function Home() {
 

  React.useEffect(()=>{    
     if( typeof WDOT !== 'undefined' ){
       /**
        * 홈 화면에 대한 페이지 정보 전송 
        ***/ 
       WDOT.logScreen({
            page_id : "index.js"
       });   
     } 
  },[]); 

  const router = useRouter();
  return (
    <div className="container">
      <Head>
        <title>NextJs Example for website</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main>
        <h2>
          NextJS 언어로 개발된 웹사이트에 WISETRACKER SDK 적용 하는 방법 
        </h2>
 
        <div className="grid">
          <a className="card" onClick={() => {
             /**
              * 회원가입 이벤트  정보 전송 
              ***/             
              WDOT.logEvent({
                event : "w_signup_complete",
                signupTp : "email"
              }); 
              alert('회원가입 이벤트 데이터가 서버로 전송되었습니다.'); 
          }}>
            <h3>회원가입 이벤트</h3>
            <p>SDK를 통해서 회원가입 이벤트 데이터를 전송합니다.</p>
          </a>

          <a className="card" onClick={() => {
              /**
              * 로그인 정보 전송 
              ***/          
              WDOT.setUser({
                mbr:"Y",
                sx : "male",
                ag : "20-29",
                ut1 : "platinum" 
              });  
              WDOT.logEvent({
                event : "w_login_complete",
                loginTp : "kakao"
              });

              alert('로그인 이벤트 데이터가 서버로 전송되었습니다.'); 
          }}>
            <h3>로그인 이벤트</h3>
            <p>SDK를 통해서 로그인 이벤트 데이터를 전송합니다.</p>
          </a>
 
          <a className="card" onClick={() => router.push("/productView")} >
            <h3>상품 상세 페이지 이동</h3>
            <p>상품 상세 페이지로 이동합니다.</p>
          </a> 

          <a className="card" onClick={() => router.push("/purchase")} >
            <h3>결제 완료 페이지 이동</h3>
            <p>구매 완료 페이지로 이동하여, 결제 정보를 전송합니다.</p>
          </a> 

          <a className="card" onClick={() => router.push("/event")} >
            <h3>이벤트 페이지 이동</h3>
            <p>이벤트 페이지로 이동합니다.</p>
          </a> 

        </div>
      </main>

      <footer>
        <a
          href="https://vercel.com?utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
          target="_blank"
          rel="noopener noreferrer"
        >
          Powered by{' '}
          <img src="/vercel.svg" alt="Vercel" className="logo" />
        </a>
      </footer>

      
    </div>
  )
}
