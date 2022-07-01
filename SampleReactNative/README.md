

npm install 

npm install --save git+https://github.com/WisetrackerTechteam/RW-react-package.git

# Android 

# IOS

- dotAuthorizationKey 키 추가. 
<key>dotAuthorizationKey</key>
<dict>
    <key>serviceNumber</key>
    <string>xxxxx</string>
    <key>expireDate</key>
    <string>14</string>
    <key>isDebug</key>
    <string>true</string>
    <key>isInstallRetention</key>
    <string>true</string>
    <key>isFingerPrint</key>
    <string>true</string>
    <key>accessToken</key>
    <string></string>
    <key>useMode</key>
    <string>2</string>
</dict>

- NSAppTransportSecurity 설정은 이미 info.plist 파일에 존재하고 있었음. 
<key>NSAppTransportSecurity</key>
<dict>
    <key>NSAllowsArbitraryLoads</key>
    <true/>
</dict>


- SDK 추가 및 설치 
pod install 
pod install --repo-update


- 위 상태에서 "npm run ios" 실행 시키면 아래와 같은 오류 나타남. 

❌  (ios/SampleReactNative/AppDelegate.mm:61:4)

  59 |   // #############################################################
  60 |   // S: Wisetracker SDK init
> 61 |   [DOT initialization:launchOptions application:application];
     |    ^ use of undeclared identifier 'DOT'
  62 |   #ifdef DEBUG
  63 |     [DOT checkDebugMode:true]
  64 |   #else
 
 

 - SampleReactNative.xcworkspace 파일을 더블클릭해서 Xcode로 해당 프로젝트를 오픈함. 




