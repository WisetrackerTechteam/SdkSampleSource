# Android 

allprojects {
    repositories {
        google()
        mavenCentral()
        /* sdk repository url 추가 */ 
        maven { url 'https://wisetracker.jfrog.io/artifactory/wisetracker-gradle-release-local' }
    }
}

dependencies {
    implementation fileTree(dir: 'libs', include: ['*.jar'])
    ....
    // SDK
    implementation "com.sdk.wisetracker:base_module:1.0.70"
    implementation "com.sdk.wisetracker:new_dot_module:1.0.36"
}



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

- Xcode 로 ios 프로젝트를 열고, DotReactBridge 객체를 프로젝트에 추가. 

- 그리고 컴파일 해야 sdk 호출이 가능해짐. 


