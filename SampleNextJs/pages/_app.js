import App from 'next/app'
import React from "react" 
import WDOTInitialization from "dop-website-sdk" 
import '../styles/global.css'

function MyApp({ Component, pageProps }) {

  /**
   * WiseTracker SDK 초기화  
   **/
  React.useEffect(()=>{ 
    if( window.WDOT == undefined ){
      window.WDOTInitialization.setConfig({
          serviceNumber:102,
          dotAccessToken:"7oGUQDmojFDLNqP+lj77clTq7SVpQ9/b/SgBCEyB9kL4kJcvn+XF++v4/oNUSZ0WI2nVYKDDckUSrcVnrkSWILdvUdow0PlKah3CJVVpj5wQEyafUSAxIjtZL292U4cs",
          combackUserLimitDays:14,
          dotEndPoint:"https://trk.analytics.wisetracker.co.kr/web/v1/dataRcv.do",
          adClkEndPoint:"https://trk.analytics.wisetracker.co.kr/ldsys/v1/clickDataRcv.do",
          adLandingEndPoint:"https://app.wisetracker.co.kr",
          includeUrl:"localhost|192.168.0.3|wisetracker.co.kr|analytics.wisetracker.co.kr|sk7mobile.com",
          excludeUrl:"",
          referrerExpire:7
      });
      window.WDOTInitialization.init();   
    }  
  },[]); 


  return <Component {...pageProps} />
} 

MyApp.getInitialProps = async (appContext) => {
  const appProps = await App.getInitialProps(appContext)  
  return { ...appProps }
} 
export default MyApp