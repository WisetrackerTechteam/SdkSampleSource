//import the basics.
#import <DOT/DOT.h>
#import "DOTNativeBridge.h"
#import "UnityAppController.h" //our link to the base class.
#include <map>
#include <string>

//------- start header ----------------
//start interface.
@interface DOTUnityAppController : UnityAppController //extend from UnityAppController.


//end interface.
@end

//------- start body ---------------
static DOTUnityAppController *delegateObject; // --- a static object is defined to be called from "extern" method.
//Purchase *purchase;
//NSMutableArray *productList;
@implementation DOTUnityAppController


// overriding main unity entry point.
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    [super application:application didFinishLaunchingWithOptions:launchOptions];
    /**
             sdk 초기화
     */
    NSLog(@"init call");
    [DOT initialization:launchOptions application:application];
    #ifdef DEBUG
        [DOT checkDebugMode:true];
    #else
        [DOT checkDebugMode:false];
    #endif
    delegateObject = self; // --- we assign this instance to the static delegateObject.

    return YES;
}
- (BOOL)application:(UIApplication*)app openURL:(NSURL*)url options:(NSDictionary<NSString*, id>*)options
{
    
    [super application:app openURL:url options:options];
    [DOT setDeepLink:[url absoluteString]];
    
    return YES;
}
//- (void) startUnity: (UIApplication*) application {
//    [super startUnity: application]; //call the super.
//    delegateObject = self; // --- we assign this instance to the static delegateObject.
//}

@end

//setting this as app controller.
IMPL_APP_CONTROLLER_SUBCLASS( DOTUnityAppController )