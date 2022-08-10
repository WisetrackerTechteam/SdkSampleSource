//
//  DOTNativeBridge.m
//  Unity-iPhone
//
//  Created by Woncheol Heo on 2019. 1. 14..
//

#import <Foundation/Foundation.h>
#import <DOT/DOT.h>
#import "DOTNativeBridge.h"


@interface DotNativeBridge : NSObject

@end

Purchase *purchase;
NSMutableArray *productList;
Product *product;
@implementation DotNativeBridge

- (instancetype)init {
    return self;
}

User *converToDotUser(UserIos userIos) {
    User *user = [[User alloc] init];
    
    if(userIos.member) {
        user.member = DotCreateNSString(userIos.member);
    }
    if(userIos.gender) {
        user.gender = DotCreateNSString(userIos.gender);
    }
    if(userIos.age) {
        user.age = DotCreateNSString(userIos.age);
    }
    if(userIos.attribute1) {
        user.attribute1 = DotCreateNSString(userIos.attribute1);
    }
    if(userIos.attribute2) {
        user.attribute2 = DotCreateNSString(userIos.attribute2);
    }
    if(userIos.attribute3) {
        user.attribute3 = DotCreateNSString(userIos.attribute3);
    }
    if(userIos.attribute4) {
        user.attribute4 = DotCreateNSString(userIos.attribute4);
    }
    if(userIos.attribute5) {
        user.attribute5 = DotCreateNSString(userIos.attribute5);
    }
    if(userIos.memberGrade) {
        user.memberGrade = DotCreateNSString(userIos.memberGrade);
    }
    if(userIos.memberId) {
        user.memberId = DotCreateNSString(userIos.memberId);
    }
    if(userIos.isLogin) {
        user.isLogin = DotCreateNSString(userIos.isLogin);
    }
    
    return user;
}
    
#pragma mark - Helper Methods

// Converts C style string to NSString
NSString* DotCreateNSString (const char* string)
{
    NSLog(@"parameter: %s", string);
    NSLog(@"converting: %@", [NSString stringWithUTF8String:string ?: ""]);
    return [NSString stringWithUTF8String:string ?: ""];
    //NSString* justName = [[NSString alloc] initWithUTF8String:string]; // -- convert from C style to Objective C style.
}

NSData* DotCreateNSData (Byte bytes[], NSUInteger length)
{
    if(bytes)
    {
        return [NSData dataWithBytes:bytes length:length];
    }
    else
    {
        return nil;
    }
}

char* AutonomousStringCopy (const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

extern "C" { // -- we define our external method to be in C.
    
    void CallSetPushClick(const char*  pushId, const char*  campaignId, const char*  pushTitle, const char*  pushBody, long expireTime){
        // Native sdk 수정 필요
    }
    void CallSetPushReceiver(const char* campaignId, const char* pushID){
        // Native sdk 수정 필요
    }
    
    void CallSetDeepLink(const char* deeplink){
        NSString *dl = DotCreateNSString(deeplink);
        [DOT setDeepLink:dl];
    }
    
    void CallSetPushToken(const char* pushToken){
        NSString *pushtk = DotCreateNSString(pushToken);
        [DOT setPushToken:pushtk];
    }
    
    
    void CallSetUser(UserIos userIos) {
        User *user = [[User alloc] init];
        
        user = converToDotUser(userIos);
        [DOT setUser:user];
    }
    
    void CallSetUserLogout(){
        [DOT setUserLogout];
    }
    
    
    
    
    void CallStartPage() {
        [DOT onStartPage];
    }
    
    void CallStopPage() {
        [DOT onStopPage];
    } 
    
    void CallLogEvent(const char* jsonStr) {
       NSString *eventStr = DotCreateNSString(jsonStr);
       
       NSLog(@"============ eventStr : %@================", eventStr);
       NSData *jsonData = [eventStr dataUsingEncoding:NSUTF8StringEncoding];
       NSError *error;
       NSMutableDictionary *eventDict = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingMutableContainers error:&error];
       [DOT logEvent:eventDict];
    }
    
    void CallLogClick(const char* jsonStr) {
       NSString *clickStr = DotCreateNSString(jsonStr);
       
       NSLog(@"============ clickStr : %@================", clickStr);
       NSData *jsonData = [clickStr dataUsingEncoding:NSUTF8StringEncoding];
       NSError *error;
       NSMutableDictionary *clickDict = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingMutableContainers error:&error];
       [DOT logClick:clickDict];
    }
    
    void CallLogScreen(const char* jsonStr) {
       NSString *screenStr = DotCreateNSString(jsonStr);
       
       NSLog(@"============ screenStr : %@================", screenStr);
       NSData *jsonData = [screenStr dataUsingEncoding:NSUTF8StringEncoding];
       NSError *error;
       NSMutableDictionary *screenDic = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingMutableContainers error:&error];
       [DOT logScreen:screenDic];
    }
    
    void CallLogPurchase(const char* jsonStr) {
       NSString *puchaseStr = DotCreateNSString(jsonStr);
       
       NSLog(@"============ puchaseStr : %@================", puchaseStr);
       NSData *jsonData = [puchaseStr dataUsingEncoding:NSUTF8StringEncoding];
       NSError *error;
       NSMutableDictionary *purchaseDic = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingMutableContainers error:&error];
       [DOT logPurchase:purchaseDic];
    }
}
@end





