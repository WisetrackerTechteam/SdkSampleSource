//
//  DOTNativeBridge.m
//  Unity-iPhone
//
//  Created by Woncheol Heo on 2019. 1. 14..
//

#import <Foundation/Foundation.h>
#import "DOT.h"
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

Click *convertToDotClick(ClickIos clickIos)
{
    Click *click = [[Click alloc] init];
    CustomValue *customValue = [[CustomValue alloc] init];
    
    if(clickIos.customValue.value1) {
        customValue.value1 = DotCreateNSString(clickIos.customValue.value1);
    }
    if(clickIos.customValue.value2) {
        customValue.value2 = DotCreateNSString(clickIos.customValue.value2);
    }
    if(clickIos.customValue.value3) {
        customValue.value3 = DotCreateNSString(clickIos.customValue.value3);
    }
    if(clickIos.customValue.value4) {
        customValue.value4 = DotCreateNSString(clickIos.customValue.value4);
    }
    if(clickIos.customValue.value4) {
        customValue.value5 = DotCreateNSString(clickIos.customValue.value5);
    }
    if(clickIos.customValue.value5) {
        customValue.value6 = DotCreateNSString(clickIos.customValue.value6);
    }
    if(clickIos.customValue.value6) {
        customValue.value7 = DotCreateNSString(clickIos.customValue.value7);
    }
    if(clickIos.customValue.value8) {
        customValue.value8 = DotCreateNSString(clickIos.customValue.value8);
    }
    if(clickIos.customValue.value9) {
        customValue.value9 = DotCreateNSString(clickIos.customValue.value9);
    }
    if(clickIos.customValue.value10) {
        customValue.value10 = DotCreateNSString(clickIos.customValue.value10);
    }
    
    if(clickIos.clickType) {
        click.ckTp = DotCreateNSString(clickIos.clickType);
        if([click.ckTp isEqualToString:@"SCRT"]) {
            if(productList.count > 0) {
                [click addCartProductList:productList];
            }
            else if(productList.count == 0) {
                [click addCartProduct:product];
            }
        }
    }
    if(clickIos.clickData) {
        click.ckData = DotCreateNSString(clickIos.clickData);
    }
    
    [click setCustomValue:customValue];
    return click;
    
}

Conversion *convertToDotConversion(ConversionIos conversionIos)
{
    Conversion *conversion = [[Conversion alloc] init];
    
    CustomValue *customValue = [[CustomValue alloc] init];
    if(conversionIos.customValue.value1) {
        customValue.value1 = DotCreateNSString(conversionIos.customValue.value1);
    }
    if(conversionIos.customValue.value2) {
        customValue.value2 = DotCreateNSString(conversionIos.customValue.value2);
    }
    if(conversionIos.customValue.value3) {
        customValue.value3 = DotCreateNSString(conversionIos.customValue.value3);
    }
    if(conversionIos.customValue.value4) {
        customValue.value4 = DotCreateNSString(conversionIos.customValue.value4);
    }
    if(conversionIos.customValue.value5) {
        customValue.value5 = DotCreateNSString(conversionIos.customValue.value5);
    }
    if(conversionIos.customValue.value6) {
        customValue.value6 = DotCreateNSString(conversionIos.customValue.value6);
    }
    if(conversionIos.customValue.value7) {
        customValue.value7 = DotCreateNSString(conversionIos.customValue.value7);
    }
    if(conversionIos.customValue.value8) {
        customValue.value8 = DotCreateNSString(conversionIos.customValue.value8);
    }
    if(conversionIos.customValue.value9) {
        customValue.value9 = DotCreateNSString(conversionIos.customValue.value9);
    }
    if(conversionIos.customValue.value10) {
        customValue.value10 = DotCreateNSString(conversionIos.customValue.value10);
    }
    
    Product *product = [[Product alloc] init];
    
    if(conversionIos.product.firstCategory) {
        product.firstCategory = DotCreateNSString(conversionIos.product.firstCategory);
    }
    if(conversionIos.product.secondCategory) {
        product.secondCategory = DotCreateNSString(conversionIos.product.secondCategory);
    }
    if(conversionIos.product.thirdCategory) {
        product.thirdCategory = DotCreateNSString(conversionIos.product.thirdCategory);
    }
    if(conversionIos.product.detailCategory) {
        product.detailCategory = DotCreateNSString(conversionIos.product.detailCategory);
    }
    if(conversionIos.product.attribute1) {
        product.attribute1 = DotCreateNSString(conversionIos.product.attribute1);
    }
    if(conversionIos.product.attribute2) {
        product.attribute2 = DotCreateNSString(conversionIos.product.attribute2);
    }
    if(conversionIos.product.attribute3) {
        product.attribute3 = DotCreateNSString(conversionIos.product.attribute3);
    }
    if(conversionIos.product.attribute4) {
        product.attribute4 = DotCreateNSString(conversionIos.product.attribute4);
    }
    if(conversionIos.product.attribute5) {
        product.attribute5 = DotCreateNSString(conversionIos.product.attribute5);
    }
    if(conversionIos.product.attribute6) {
        product.attribute6 = DotCreateNSString(conversionIos.product.attribute6);
    }
    if(conversionIos.product.attribute7) {
        product.attribute7 = DotCreateNSString(conversionIos.product.attribute7);
    }
    if(conversionIos.product.attribute8) {
        product.attribute8 = DotCreateNSString(conversionIos.product.attribute8);
    }
    if(conversionIos.product.attribute9) {
        product.attribute9 = DotCreateNSString(conversionIos.product.attribute9);
    }
    if(conversionIos.product.attribute10) {
        product.attribute10 = DotCreateNSString(conversionIos.product.attribute10);
    }
    
    if(conversionIos.microConversion1) {
        [conversion setMicroConversion1:conversionIos.microConversion1];
    }
    if(conversionIos.microConversion2) {
        [conversion setMicroConversion2:conversionIos.microConversion2];
    }
    if(conversionIos.microConversion3) {
        [conversion setMicroConversion3:conversionIos.microConversion3];
    }
    if(conversionIos.microConversion4) {
        [conversion setMicroConversion4:conversionIos.microConversion4];
    }
    if(conversionIos.microConversion5) {
        [conversion setMicroConversion5:conversionIos.microConversion5];
    }
    if(conversionIos.microConversion6) {
        [conversion setMicroConversion6:conversionIos.microConversion6];
    }
    if(conversionIos.microConversion7) {
        [conversion setMicroConversion7:conversionIos.microConversion7];
    }
    if(conversionIos.microConversion8) {
        [conversion setMicroConversion8:conversionIos.microConversion8];
    }
    if(conversionIos.microConversion9) {
        [conversion setMicroConversion9:conversionIos.microConversion9];
    }
    if(conversionIos.microConversion10) {
        [conversion setMicroConversion10:conversionIos.microConversion10];
    }
    if(conversionIos.microConversion11) {
        [conversion setMicroConversion11:conversionIos.microConversion11];
    }
    if(conversionIos.microConversion12) {
        [conversion setMicroConversion12:conversionIos.microConversion12];
    }
    if(conversionIos.microConversion13) {
        [conversion setMicroConversion3:conversionIos.microConversion13];
    }
    if(conversionIos.microConversion14) {
        [conversion setMicroConversion14:conversionIos.microConversion14];
    }
    if(conversionIos.microConversion15) {
        [conversion setMicroConversion15:conversionIos.microConversion15];
    }
    if(conversionIos.microConversion16) {
        [conversion setMicroConversion16:conversionIos.microConversion16];
    }
    if(conversionIos.microConversion17) {
        [conversion setMicroConversion17:conversionIos.microConversion17];
    }
    if(conversionIos.microConversion18) {
        [conversion setMicroConversion18:conversionIos.microConversion18];
    }
    if(conversionIos.microConversion19) {
        [conversion setMicroConversion19:conversionIos.microConversion19];
    }
    if(conversionIos.microConversion20) {
        [conversion setMicroConversion20:conversionIos.microConversion20];
    }
    if(conversionIos.microConversion21) {
        [conversion setMicroConversion21:conversionIos.microConversion21];
    }
    if(conversionIos.microConversion22) {
        [conversion setMicroConversion22:conversionIos.microConversion22];
    }
    if(conversionIos.microConversion23) {
        [conversion setMicroConversion23:conversionIos.microConversion23];
    }
    if(conversionIos.microConversion24) {
        [conversion setMicroConversion24:conversionIos.microConversion24];
    }
    if(conversionIos.microConversion25) {
        [conversion setMicroConversion25:conversionIos.microConversion25];
    }
    if(conversionIos.microConversion26) {
        [conversion setMicroConversion26:conversionIos.microConversion26];
    }
    if(conversionIos.microConversion27) {
        [conversion setMicroConversion27:conversionIos.microConversion27];
    }
    if(conversionIos.microConversion28) {
        [conversion setMicroConversion28:conversionIos.microConversion28];
    }
    if(conversionIos.microConversion29) {
        [conversion setMicroConversion29:conversionIos.microConversion29];
    }
    if(conversionIos.microConversion30) {
        [conversion setMicroConversion30:conversionIos.microConversion30];
    }
    if(conversionIos.microConversion31) {
        [conversion setMicroConversion31:conversionIos.microConversion31];
    }
    if(conversionIos.microConversion32) {
        [conversion setMicroConversion32:conversionIos.microConversion32];
    }
    if(conversionIos.microConversion33) {
        [conversion setMicroConversion33:conversionIos.microConversion33];
    }
    if(conversionIos.microConversion34) {
        [conversion setMicroConversion34:conversionIos.microConversion34];
    }
    if(conversionIos.microConversion35) {
        [conversion setMicroConversion35:conversionIos.microConversion35];
    }
    if(conversionIos.microConversion36) {
        [conversion setMicroConversion36:conversionIos.microConversion36];
    }
    if(conversionIos.microConversion37) {
        [conversion setMicroConversion37:conversionIos.microConversion37];
    }
    if(conversionIos.microConversion38) {
        [conversion setMicroConversion38:conversionIos.microConversion38];
    }
    if(conversionIos.microConversion39) {
        [conversion setMicroConversion39:conversionIos.microConversion39];
    }
    if(conversionIos.microConversion40) {
        [conversion setMicroConversion40:conversionIos.microConversion40];
    }
    if(conversionIos.microConversion41) {
        [conversion setMicroConversion41:conversionIos.microConversion41];
    }
    if(conversionIos.microConversion42) {
        [conversion setMicroConversion42:conversionIos.microConversion42];
    }
    if(conversionIos.microConversion43) {
        [conversion setMicroConversion44:conversionIos.microConversion43];
    }
    if(conversionIos.microConversion44) {
        [conversion setMicroConversion44:conversionIos.microConversion44];
    }
    if(conversionIos.microConversion45) {
        [conversion setMicroConversion45:conversionIos.microConversion45];
    }
    if(conversionIos.microConversion46) {
        [conversion setMicroConversion46:conversionIos.microConversion46];
    }
    if(conversionIos.microConversion47) {
        [conversion setMicroConversion47:conversionIos.microConversion47];
    }
    if(conversionIos.microConversion48) {
        [conversion setMicroConversion48:conversionIos.microConversion48];
    }
    if(conversionIos.microConversion49) {
        [conversion setMicroConversion49:conversionIos.microConversion49];
    }
    if(conversionIos.microConversion50) {
        [conversion setMicroConversion50:conversionIos.microConversion50];
    }
    if(conversionIos.microConversion51) {
        [conversion setMicroConversion51:conversionIos.microConversion51];
    }
    if(conversionIos.microConversion52) {
        [conversion setMicroConversion52:conversionIos.microConversion52];
    }
    if(conversionIos.microConversion53) {
        [conversion setMicroConversion55:conversionIos.microConversion53];
    }
    if(conversionIos.microConversion54) {
        [conversion setMicroConversion54:conversionIos.microConversion54];
    }
    if(conversionIos.microConversion55) {
        [conversion setMicroConversion55:conversionIos.microConversion55];
    }
    if(conversionIos.microConversion56) {
        [conversion setMicroConversion56:conversionIos.microConversion56];
    }
    if(conversionIos.microConversion57) {
        [conversion setMicroConversion57:conversionIos.microConversion57];
    }
    if(conversionIos.microConversion58) {
        [conversion setMicroConversion58:conversionIos.microConversion58];
    }
    if(conversionIos.microConversion59) {
        [conversion setMicroConversion59:conversionIos.microConversion59];
    }
    if(conversionIos.microConversion60) {
        [conversion setMicroConversion60:conversionIos.microConversion60];
    }
    if(conversionIos.microConversion61) {
        [conversion setMicroConversion61:conversionIos.microConversion61];
    }
    if(conversionIos.microConversion62) {
        [conversion setMicroConversion62:conversionIos.microConversion62];
    }
    if(conversionIos.microConversion63) {
        [conversion setMicroConversion66:conversionIos.microConversion63];
    }
    if(conversionIos.microConversion64) {
        [conversion setMicroConversion64:conversionIos.microConversion64];
    }
    if(conversionIos.microConversion65) {
        [conversion setMicroConversion65:conversionIos.microConversion65];
    }
    if(conversionIos.microConversion66) {
        [conversion setMicroConversion66:conversionIos.microConversion66];
    }
    if(conversionIos.microConversion67) {
        [conversion setMicroConversion67:conversionIos.microConversion67];
    }
    if(conversionIos.microConversion68) {
        [conversion setMicroConversion68:conversionIos.microConversion68];
    }
    if(conversionIos.microConversion69) {
        [conversion setMicroConversion69:conversionIos.microConversion69];
    }
    if(conversionIos.microConversion70) {
        [conversion setMicroConversion70:conversionIos.microConversion70];
    }
    if(conversionIos.microConversion71) {
        [conversion setMicroConversion71:conversionIos.microConversion71];
    }
    if(conversionIos.microConversion72) {
        [conversion setMicroConversion72:conversionIos.microConversion72];
    }
    if(conversionIos.microConversion73) {
        [conversion setMicroConversion77:conversionIos.microConversion73];
    }
    if(conversionIos.microConversion74) {
        [conversion setMicroConversion74:conversionIos.microConversion74];
    }
    if(conversionIos.microConversion75) {
        [conversion setMicroConversion75:conversionIos.microConversion75];
    }
    if(conversionIos.microConversion76) {
        [conversion setMicroConversion76:conversionIos.microConversion76];
    }
    if(conversionIos.microConversion77) {
        [conversion setMicroConversion77:conversionIos.microConversion77];
    }
    if(conversionIos.microConversion78) {
        [conversion setMicroConversion78:conversionIos.microConversion78];
    }
    if(conversionIos.microConversion79) {
        [conversion setMicroConversion79:conversionIos.microConversion79];
    }
    if(conversionIos.microConversion80) {
        [conversion setMicroConversion80:conversionIos.microConversion80];
    }
    
    [conversion setCustomValue:customValue];
    [conversion setProduct:product];
    
    return conversion;
}

Page *convertToDotPage(PageIos pageIos) {
    
    Page *page = [[Page alloc] init];
    
    if(pageIos.pageIdentify) {
        page.pi = DotCreateNSString(pageIos.pageIdentify);
    }
    if(pageIos.contentPath) {
        page.contentPath = DotCreateNSString(pageIos.contentPath);
    }
    if(pageIos.keywordCategory) {
        page.keywordCategory = DotCreateNSString(pageIos.keywordCategory);
    }
    if(pageIos.keyword) {
        page.keyword = DotCreateNSString(pageIos.keyword);
    }
    page.searchResult = [NSNumber numberWithInt:pageIos.searchingResult];
    CustomValue *customValue = [[CustomValue alloc] init];
    
    if(pageIos.customValue.value1) {
        customValue.value1 = DotCreateNSString(pageIos.customValue.value1);
    }
    if(pageIos.customValue.value2) {
        customValue.value2 = DotCreateNSString(pageIos.customValue.value2);
    }
    if(pageIos.customValue.value3) {
        customValue.value3 = DotCreateNSString(pageIos.customValue.value3);
    }
    if(pageIos.customValue.value4) {
        customValue.value4 = DotCreateNSString(pageIos.customValue.value4);
    }
    if(pageIos.customValue.value5) {
        customValue.value5 = DotCreateNSString(pageIos.customValue.value5);
    }
    if(pageIos.customValue.value6) {
        customValue.value6 = DotCreateNSString(pageIos.customValue.value6);
    }
    if(pageIos.customValue.value7) {
        customValue.value7 = DotCreateNSString(pageIos.customValue.value7);
    }
    if(pageIos.customValue.value8) {
        customValue.value8 = DotCreateNSString(pageIos.customValue.value8);
    }
    if(pageIos.customValue.value9) {
        customValue.value9 = DotCreateNSString(pageIos.customValue.value9);
    }
    if(pageIos.customValue.value10) {
        customValue.value10 = DotCreateNSString(pageIos.customValue.value10);
    }
    
    Product *product = [[Product alloc] init];
    
    if(pageIos.product.firstCategory) {
        product.firstCategory = DotCreateNSString(pageIos.product.firstCategory);
    }
    if(pageIos.product.secondCategory) {
        product.secondCategory = DotCreateNSString(pageIos.product.secondCategory);
    }
    if(pageIos.product.thirdCategory) {
        product.thirdCategory = DotCreateNSString(pageIos.product.thirdCategory);
    }
    if(pageIos.product.detailCategory) {
        product.detailCategory = DotCreateNSString(pageIos.product.detailCategory);
    }
    if(pageIos.product.attribute1) {
        product.attribute1 = DotCreateNSString(pageIos.product.attribute1);
    }
    if(pageIos.product.attribute2) {
        product.attribute2 = DotCreateNSString(pageIos.product.attribute2);
    }
    if(pageIos.product.attribute3) {
        product.attribute3 = DotCreateNSString(pageIos.product.attribute3);
    }
    if(pageIos.product.attribute4) {
        product.attribute4 = DotCreateNSString(pageIos.product.attribute4);
    }
    if(pageIos.product.attribute5) {
        product.attribute5 = DotCreateNSString(pageIos.product.attribute5);
    }
    if(pageIos.product.attribute6) {
        product.attribute6 = DotCreateNSString(pageIos.product.attribute6);
    }
    if(pageIos.product.attribute7) {
        product.attribute7 = DotCreateNSString(pageIos.product.attribute7);
    }
    if(pageIos.product.attribute8) {
        product.attribute8 = DotCreateNSString(pageIos.product.attribute8);
    }
    if(pageIos.product.attribute9) {
        product.attribute9 = DotCreateNSString(pageIos.product.attribute9);
    }
    if(pageIos.product.attribute10) {
        product.attribute10 = DotCreateNSString(pageIos.product.attribute10);
    }
    
    [page setProduct:product];
    [page setCustomValue:customValue];
    
    return page;
}

Purchase *convertToDotPurchase(PurchaseIos purchaseIos)
{
    Purchase *purchase = [[Purchase alloc] init];
    CustomValue *customValue = [[CustomValue alloc] init];
    
    if(purchaseIos.customValue.value1) {
        customValue.value1 = DotCreateNSString(purchaseIos.customValue.value1);
    }
    if(purchaseIos.customValue.value2) {
        customValue.value2 = DotCreateNSString(purchaseIos.customValue.value2);
    }
    if(purchaseIos.customValue.value3) {
        customValue.value3 = DotCreateNSString(purchaseIos.customValue.value3);
    }
    if(purchaseIos.customValue.value4) {
        customValue.value4 = DotCreateNSString(purchaseIos.customValue.value4);
    }
    if(purchaseIos.customValue.value5) {
        customValue.value5 = DotCreateNSString(purchaseIos.customValue.value5);
    }
    if(purchaseIos.customValue.value6) {
        customValue.value6 = DotCreateNSString(purchaseIos.customValue.value6);
    }
    if(purchaseIos.customValue.value7) {
        customValue.value7 = DotCreateNSString(purchaseIos.customValue.value7);
    }
    if(purchaseIos.customValue.value8) {
        customValue.value8 = DotCreateNSString(purchaseIos.customValue.value8);
    }
    if(purchaseIos.customValue.value9) {
        customValue.value9 = DotCreateNSString(purchaseIos.customValue.value9);
    }
    if(purchaseIos.customValue.value10) {
        customValue.value10 = DotCreateNSString(purchaseIos.customValue.value10);
    }
    
    if(purchaseIos.orderNumber) {
        purchase.orderNo = DotCreateNSString(purchaseIos.orderNumber);
    }
    
    if(purchaseIos.currency) {
        purchase.currency = DotCreateNSString(purchaseIos.currency);
    }
    if(purchaseIos.keywordCategory) {
        purchase.keywordCategory = DotCreateNSString(purchaseIos.keywordCategory);
    }
    if(purchaseIos.keyword) {
        purchase.keyword = DotCreateNSString(purchaseIos.keyword);
    }
    
    [purchase setCustomValue:customValue];
    if(productList.count > 0) {
        [purchase setProductList:productList];
    }
    else if(productList.count == 0) {
        [purchase setProduct:product];
    }
    return purchase;
}

Product *convertToDotProduct(ProductIos productIos, const char* optionalAmountKeys[], double optionalAmountValues[], int optAmtCount) {
    Product *product = [[Product alloc] init];
    
    if(productIos.firstCategory) {
        product.firstCategory = DotCreateNSString(productIos.firstCategory);
    }
    if(productIos.secondCategory) {
        product.secondCategory = DotCreateNSString(productIos.secondCategory);
    }
    if(productIos.thirdCategory) {
        product.thirdCategory = DotCreateNSString(productIos.thirdCategory);
    }
    if(productIos.detailCategory) {
        product.detailCategory = DotCreateNSString(productIos.detailCategory);
    }
    if(productIos.attribute1) {
        product.attribute1 = DotCreateNSString(productIos.attribute1);
    }
    if(productIos.attribute2) {
        product.attribute2 = DotCreateNSString(productIos.attribute2);
    }
    if(productIos.attribute3) {
        product.attribute3 = DotCreateNSString(productIos.attribute3);
    }
    if(productIos.attribute4) {
        product.attribute4 = DotCreateNSString(productIos.attribute4);
    }
    if(productIos.attribute5) {
        product.attribute5 = DotCreateNSString(productIos.attribute5);
    }
    if(productIos.attribute6) {
        product.attribute6 = DotCreateNSString(productIos.attribute6);
    }
    if(productIos.attribute7) {
        product.attribute7 = DotCreateNSString(productIos.attribute7);
    }
    if(productIos.attribute8) {
        product.attribute8 = DotCreateNSString(productIos.attribute8);
    }
    if(productIos.attribute9) {
        product.attribute9 = DotCreateNSString(productIos.attribute9);
    }
    if(productIos.attribute10) {
        product.attribute10 = DotCreateNSString(productIos.attribute10);
    }
    if(productIos.productCode) {
        product.productCode = DotCreateNSString(productIos.productCode);
    }
    if(productIos.productOrderNumber) {
        product.productOrderNo = DotCreateNSString(productIos.productOrderNumber);
    }
    
    product.orderAmount = productIos.orderAmount;
    product.orderQuantity = productIos.orderQuantity;
    product.refundAmount = productIos.refundAmount;
    product.refundQuantity = productIos.refundQuantity;
    
    if(optAmtCount > 0) {
        for(int i = 0; i < optAmtCount; i++) {
            [product setOptionalAmount:DotCreateNSString(optionalAmountKeys[i]) value:optionalAmountValues[i]];
        }
    }
    
    return product;
}

Product *convertToDotProductInClick(ProductIos productIos) {
    Product *product = [[Product alloc] init];
    
    if(productIos.firstCategory) {
        product.firstCategory = DotCreateNSString(productIos.firstCategory);
    }
    if(productIos.secondCategory) {
        product.secondCategory = DotCreateNSString(productIos.secondCategory);
    }
    if(productIos.thirdCategory) {
        product.thirdCategory = DotCreateNSString(productIos.thirdCategory);
    }
    if(productIos.detailCategory) {
        product.detailCategory = DotCreateNSString(productIos.detailCategory);
    }
    if(productIos.attribute1) {
        product.attribute1 = DotCreateNSString(productIos.attribute1);
    }
    if(productIos.attribute2) {
        product.attribute2 = DotCreateNSString(productIos.attribute2);
    }
    if(productIos.attribute3) {
        product.attribute3 = DotCreateNSString(productIos.attribute3);
    }
    if(productIos.attribute4) {
        product.attribute4 = DotCreateNSString(productIos.attribute4);
    }
    if(productIos.attribute5) {
        product.attribute5 = DotCreateNSString(productIos.attribute5);
    }
    if(productIos.attribute6) {
        product.attribute6 = DotCreateNSString(productIos.attribute6);
    }
    if(productIos.attribute7) {
        product.attribute7 = DotCreateNSString(productIos.attribute7);
    }
    if(productIos.attribute8) {
        product.attribute8 = DotCreateNSString(productIos.attribute8);
    }
    if(productIos.attribute9) {
        product.attribute9 = DotCreateNSString(productIos.attribute9);
    }
    if(productIos.attribute10) {
        product.attribute10 = DotCreateNSString(productIos.attribute10);
    }
    if(productIos.productCode) {
        product.productCode = DotCreateNSString(productIos.productCode);
    }
    if(productIos.productOrderNumber) {
        product.productOrderNo = DotCreateNSString(productIos.productOrderNumber);
    }
    
    return product;
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
    
    void CallInitialization( ){
        [DOT initialization:nil application:nil]; // -- call method to plugin class
        
        purchase = [[Purchase alloc] init];
        productList = [[NSMutableArray alloc] init];
    }
    
    void CallSetUser(UserIos userIos) {
        User *user = [[User alloc] init];
        
        user = converToDotUser(userIos);
        [DOT setUser:user];
    }
    
    void CallSetClick(ClickIos clickIos) {
        Click *click = [[Click alloc] init];
        click = convertToDotClick(clickIos);
        [DOT setClick:click];
    }
    
    void CallSetConversion(ConversionIos conversionIos) {
        Conversion *conversion = [[Conversion alloc] init];
        
        conversion = convertToDotConversion(conversionIos);
        [DOT setConversion:conversion];
    }
    
    void MakeProductList(ProductIos productIos, const char* optionalAmountKeys[], double optionalAmountValues[], int optAmtCount) {
        Product *product = [[Product alloc] init];
        product = convertToDotProduct(productIos, optionalAmountKeys, optionalAmountValues, optAmtCount);
        
        [productList addObject:product];
    }
    
    void MakeProduct(ProductIos productIos, const char* optionalAmountKeys[], double optionalAmountValues[], int optAmtCount) {
        product = convertToDotProduct(productIos, optionalAmountKeys, optionalAmountValues, optAmtCount);
        
    }
    
    void MakeProductListInClick(ProductIos productIos) {
        Product *product = [[Product alloc] init];
        product = convertToDotProductInClick(productIos);
        
        [productList addObject:product];
    }
    
    void MakeProductInClick(ProductIos productIos) {
        product = convertToDotProductInClick(productIos);
    }
    
    void CallSetPurchase(PurchaseIos purchaseIos) {
        purchase = convertToDotPurchase(purchaseIos);
        
        [DOT setPurchase:purchase];
    }
    
    void CallSetPage(PageIos pageIos) {
        Page *page = [[Page alloc] init];
        page = convertToDotPage(pageIos);
        [DOT setPage:page];
        [DOT onStartPage];
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





