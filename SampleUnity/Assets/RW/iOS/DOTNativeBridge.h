//
//  Header.h
//  Unity-iPhone
//
//  Created by Woncheol Heo on 2019. 1. 14..
//


typedef struct UserIos {
    const char* member;
    const char* gender;
    const char* age;
    const char* attribute1;
    const char* attribute2;
    const char* attribute3;
    const char* attribute4;
    const char* attribute5;
    const char* memberGrade;
    const char* memberId;
    const char* isLogin;
} UserIos;

typedef struct CustomValueIos
{
    const char* value1;
    const char* value2;
    const char* value3;
    const char* value4;
    const char* value5;
    const char* value6;
    const char* value7;
    const char* value8;
    const char* value9;
    const char* value10;
} CustomValueIos;

typedef struct ProductIos {
    const char* firstCategory;
    const char* secondCategory;
    const char* thirdCategory;
    const char* detailCategory;
    const char* productCode;
    const char* attribute1;
    const char* attribute2;
    const char* attribute3;
    const char* attribute4;
    const char* attribute5;
    const char* attribute6;
    const char* attribute7;
    const char* attribute8;
    const char* attribute9;
    const char* attribute10;
    const char* productOrderNumber;
    double orderAmount;
    int orderQuantity;
    double refundAmount;
    int refundQuantity;
} ProductIos;

typedef struct ConversionIos
{
    const CustomValueIos customValue;
    const ProductIos product;
    const char* keywordCategory;
    const char* keyword;
    double microConversion1;
    double microConversion2;
    double microConversion3;
    double microConversion4;
    double microConversion5;
    double microConversion6;
    double microConversion7;
    double microConversion8;
    double microConversion9;
    double microConversion10;
    double microConversion11;
    double microConversion12;
    double microConversion13;
    double microConversion14;
    double microConversion15;
    double microConversion16;
    double microConversion17;
    double microConversion18;
    double microConversion19;
    double microConversion20;
    double microConversion21;
    double microConversion22;
    double microConversion23;
    double microConversion24;
    double microConversion25;
    double microConversion26;
    double microConversion27;
    double microConversion28;
    double microConversion29;
    double microConversion30;
    double microConversion31;
    double microConversion32;
    double microConversion33;
    double microConversion34;
    double microConversion35;
    double microConversion36;
    double microConversion37;
    double microConversion38;
    double microConversion39;
    double microConversion40;
    double microConversion41;
    double microConversion42;
    double microConversion43;
    double microConversion44;
    double microConversion45;
    double microConversion46;
    double microConversion47;
    double microConversion48;
    double microConversion49;
    double microConversion50;
    double microConversion51;
    double microConversion52;
    double microConversion53;
    double microConversion54;
    double microConversion55;
    double microConversion56;
    double microConversion57;
    double microConversion58;
    double microConversion59;
    double microConversion60;
    double microConversion61;
    double microConversion62;
    double microConversion63;
    double microConversion64;
    double microConversion65;
    double microConversion66;
    double microConversion67;
    double microConversion68;
    double microConversion69;
    double microConversion70;
    double microConversion71;
    double microConversion72;
    double microConversion73;
    double microConversion74;
    double microConversion75;
    double microConversion76;
    double microConversion77;
    double microConversion78;
    double microConversion79;
    double microConversion80;
    bool pushAgreement;
} ConversionIos;

typedef struct ClickIos
{
    const CustomValueIos customValue;
    const ProductIos product;
    const char* clickType;
    const char* clickData;
} ClickIos;

typedef struct PageIos
{
    const CustomValueIos customValue;
    const ProductIos product;
    const char* pageIdentify;
    const char* contentPath;
    const char* keywordCategory;
    const char* keyword;
    int searchingResult;
} PageIos;

typedef struct PurchaseIos
{
    const CustomValueIos customValue;
    const ProductIos product;
    const char* orderNumber;
    const char* currency;
    const char* keywordCategory;
    const char* keyword;
    
    bool useLatestSearchKeyword;
    bool useLatestCustomValue1;
    bool useLatestCustomValue2;
    bool useLatestCustomValue3;
    bool useLatestCustomValue4;
    bool useLatestCustomValue5;
    bool useLatestCustomValue6;
    bool useLatestCustomValue7;
    bool useLatestCustomValue8;
    bool useLatestCustomValue9;
    bool useLatestCustomValue10;
} PurchaseIos;

