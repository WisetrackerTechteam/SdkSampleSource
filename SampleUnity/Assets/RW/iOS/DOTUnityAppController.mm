//import the basics.
#import "DOT.h" //our newly made plugin.
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

- (void) startUnity: (UIApplication*) application {
    [super startUnity: application]; //call the super.

    delegateObject = self; // --- we assign this instance to the static delegateObject.
}

@end

//setting this as app controller.
IMPL_APP_CONTROLLER_SUBCLASS( DOTUnityAppController )




















