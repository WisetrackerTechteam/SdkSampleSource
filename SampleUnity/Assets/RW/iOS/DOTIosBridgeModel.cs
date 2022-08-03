using System;
using DOT_Model;

namespace DOTIosBridgeModel
{
    public struct UserIos
    {
        public string member;
        public string gender;
        public string age;
        public string attr1;
        public string attr2;
        public string attr3;
        public string attr4;
        public string attr5;
        public string memberGrade;
        public string memberId;
        public Boolean isLogin;

        public UserIos(User user)
        {
            this.member = user.getMember();
            this.gender = user.getGender();
            this.age = user.getAge();
            this.attr1 = user.getAttr1();
            this.attr2 = user.getAttr2();
            this.attr3 = user.getAttr3();
            this.attr4 = user.getAttr4();
            this.attr5 = user.getAttr5();
            this.memberGrade = user.getMemberGrade();
            this.memberId = user.getMemberId();
            this.isLogin = user.getIsLogin();
        }
    }

    public struct ProductIos
    {

        public string firstCategory;
        public string secondCategory;
        public string thirdCategory;
        public string detailCategory;
        public string productCode;
        public string attr1;
        public string attr2;
        public string attr3;
        public string attr4;
        public string attr5;
        public string attr6;
        public string attr7;
        public string attr8;
        public string attr9;
        public string attr10;
        public string productOrderNo;
        public double orderAmount;
        public int orderQuantity;
        public double refundAmount;
        public int refundQuantity;


        public ProductIos(Product product)
        {
            this.firstCategory = product.getFirstCategory();
            this.secondCategory = product.getSecondCategory();
            this.thirdCategory = product.getThirdCategory();
            this.detailCategory = product.getDetailCategory();
            this.productCode = product.getProductCode();
            this.attr1 = product.getAttr1();
            this.attr2 = product.getAttr2();
            this.attr3 = product.getAttr3();
            this.attr4 = product.getAttr4();
            this.attr5 = product.getAttr5();
            this.attr6 = product.getAttr6();
            this.attr7 = product.getAttr7();
            this.attr8 = product.getAttr8();
            this.attr9 = product.getAttr9();
            this.attr10 = product.getAttr10();
            this.productOrderNo = product.getProductOrderNo();
            this.orderAmount = product.getOrderAmount();
            this.orderQuantity = product.getOrderQuantity();
            this.refundAmount = product.getRefundAmount();
            this.refundQuantity = product.getRefundQuantity();
        }
    }

    public struct ConversionIos
    {
        public CustomValue customValue;
        public ProductIos productIos;
        public string keywordCategory;
        public string keyword;
        public double microConversion1;
        public double microConversion2;
        public double microConversion3;
        public double microConversion4;
        public double microConversion5;
        public double microConversion6;
        public double microConversion7;
        public double microConversion8;
        public double microConversion9;
        public double microConversion10;
        public double microConversion11;
        public double microConversion12;
        public double microConversion13;
        public double microConversion14;
        public double microConversion15;
        public double microConversion16;
        public double microConversion17;
        public double microConversion18;
        public double microConversion19;
        public double microConversion20;
        public double microConversion21;
        public double microConversion22;
        public double microConversion23;
        public double microConversion24;
        public double microConversion25;
        public double microConversion26;
        public double microConversion27;
        public double microConversion28;
        public double microConversion29;
        public double microConversion30;
        public double microConversion31;
        public double microConversion32;
        public double microConversion33;
        public double microConversion34;
        public double microConversion35;
        public double microConversion36;
        public double microConversion37;
        public double microConversion38;
        public double microConversion39;
        public double microConversion40;
        public double microConversion41;
        public double microConversion42;
        public double microConversion43;
        public double microConversion44;
        public double microConversion45;
        public double microConversion46;
        public double microConversion47;
        public double microConversion48;
        public double microConversion49;
        public double microConversion50;
        public double microConversion51;
        public double microConversion52;
        public double microConversion53;
        public double microConversion54;
        public double microConversion55;
        public double microConversion56;
        public double microConversion57;
        public double microConversion58;
        public double microConversion59;
        public double microConversion60;
        public double microConversion61;
        public double microConversion62;
        public double microConversion63;
        public double microConversion64;
        public double microConversion65;
        public double microConversion66;
        public double microConversion67;
        public double microConversion68;
        public double microConversion69;
        public double microConversion70;
        public double microConversion71;
        public double microConversion72;
        public double microConversion73;
        public double microConversion74;
        public double microConversion75;
        public double microConversion76;
        public double microConversion77;
        public double microConversion78;
        public double microConversion79;
        public double microConversion80;
        public bool pushAgreement;

        public ConversionIos(Conversion conversion)
        {
            this.customValue = conversion.getCustomValue();
            this.productIos = new ProductIos(conversion.getProduct());
            this.keywordCategory = conversion.getKeywordCategory();
            this.keyword = conversion.getKeyword();
            this.microConversion1 = conversion.getMicroConversion1();

            this.microConversion1 = conversion.getMicroConversion1();
            this.microConversion2 = conversion.getMicroConversion2();
            this.microConversion3 = conversion.getMicroConversion3();
            this.microConversion4 = conversion.getMicroConversion4();
            this.microConversion5 = conversion.getMicroConversion5();
            this.microConversion6 = conversion.getMicroConversion6();
            this.microConversion7 = conversion.getMicroConversion7();
            this.microConversion8 = conversion.getMicroConversion8();
            this.microConversion9 = conversion.getMicroConversion9();
            this.microConversion10 = conversion.getMicroConversion10();
            this.microConversion11 = conversion.getMicroConversion11();
            this.microConversion12 = conversion.getMicroConversion12();
            this.microConversion13 = conversion.getMicroConversion13();
            this.microConversion14 = conversion.getMicroConversion14();
            this.microConversion15 = conversion.getMicroConversion15();
            this.microConversion16 = conversion.getMicroConversion16();
            this.microConversion17 = conversion.getMicroConversion17();
            this.microConversion18 = conversion.getMicroConversion18();
            this.microConversion19 = conversion.getMicroConversion19();
            this.microConversion20 = conversion.getMicroConversion20();
            this.microConversion21 = conversion.getMicroConversion21();
            this.microConversion22 = conversion.getMicroConversion22();
            this.microConversion23 = conversion.getMicroConversion23();
            this.microConversion24 = conversion.getMicroConversion24();
            this.microConversion25 = conversion.getMicroConversion25();
            this.microConversion26 = conversion.getMicroConversion26();
            this.microConversion27 = conversion.getMicroConversion27();
            this.microConversion28 = conversion.getMicroConversion28();
            this.microConversion29 = conversion.getMicroConversion29();
            this.microConversion30 = conversion.getMicroConversion30();
            this.microConversion31 = conversion.getMicroConversion31();
            this.microConversion32 = conversion.getMicroConversion32();
            this.microConversion33 = conversion.getMicroConversion33();
            this.microConversion34 = conversion.getMicroConversion34();
            this.microConversion35 = conversion.getMicroConversion35();
            this.microConversion36 = conversion.getMicroConversion36();
            this.microConversion37 = conversion.getMicroConversion37();
            this.microConversion38 = conversion.getMicroConversion38();
            this.microConversion39 = conversion.getMicroConversion39();
            this.microConversion40 = conversion.getMicroConversion40();
            this.microConversion41 = conversion.getMicroConversion41();
            this.microConversion42 = conversion.getMicroConversion42();
            this.microConversion43 = conversion.getMicroConversion43();
            this.microConversion44 = conversion.getMicroConversion44();
            this.microConversion45 = conversion.getMicroConversion45();
            this.microConversion46 = conversion.getMicroConversion46();
            this.microConversion47 = conversion.getMicroConversion47();
            this.microConversion48 = conversion.getMicroConversion48();
            this.microConversion49 = conversion.getMicroConversion49();
            this.microConversion50 = conversion.getMicroConversion50();
            this.microConversion51 = conversion.getMicroConversion51();
            this.microConversion52 = conversion.getMicroConversion52();
            this.microConversion53 = conversion.getMicroConversion53();
            this.microConversion54 = conversion.getMicroConversion54();
            this.microConversion55 = conversion.getMicroConversion55();
            this.microConversion56 = conversion.getMicroConversion56();
            this.microConversion57 = conversion.getMicroConversion57();
            this.microConversion58 = conversion.getMicroConversion58();
            this.microConversion59 = conversion.getMicroConversion59();
            this.microConversion60 = conversion.getMicroConversion60();
            this.microConversion61 = conversion.getMicroConversion61();
            this.microConversion62 = conversion.getMicroConversion62();
            this.microConversion63 = conversion.getMicroConversion63();
            this.microConversion64 = conversion.getMicroConversion64();
            this.microConversion65 = conversion.getMicroConversion65();
            this.microConversion66 = conversion.getMicroConversion66();
            this.microConversion67 = conversion.getMicroConversion67();
            this.microConversion68 = conversion.getMicroConversion68();
            this.microConversion69 = conversion.getMicroConversion69();
            this.microConversion70 = conversion.getMicroConversion70();
            this.microConversion71 = conversion.getMicroConversion71();
            this.microConversion72 = conversion.getMicroConversion72();
            this.microConversion73 = conversion.getMicroConversion73();
            this.microConversion74 = conversion.getMicroConversion74();
            this.microConversion75 = conversion.getMicroConversion75();
            this.microConversion76 = conversion.getMicroConversion76();
            this.microConversion77 = conversion.getMicroConversion77();
            this.microConversion78 = conversion.getMicroConversion78();
            this.microConversion79 = conversion.getMicroConversion79();
            this.microConversion80 = conversion.getMicroConversion80();
            this.pushAgreement = conversion.getPushAgreement();
        }
    }

    public struct PageIos
    {

        public CustomValue customValue;
        public ProductIos productIos;
        public string identity;
        public string contentPath;
        public string keywordCategory;
        public string keyword;
        public int searchResultCount;


        public PageIos(Page page)
        {
            this.customValue = page.getCustomValue();
            this.productIos = new ProductIos(page.getProduct());
            this.identity = page.getIdentity();
            this.contentPath = page.getContentPath();
            this.keywordCategory = page.getKeywordCategory();
            this.keyword = page.getKeyword();
            this.searchResultCount = page.getSearchResultCount();
        }
    }

    public struct PurchaseIos
    {

        public CustomValue customValue;
        public ProductIos productIos;
        public string orderNo;
        public string currency;
        public string keywordCategory;
        public string keyword;

        public bool useLatestSearchKeyword;
        public bool useLatestCustomValue1;
        public bool useLatestCustomValue2;
        public bool useLatestCustomValue3;
        public bool useLatestCustomValue4;
        public bool useLatestCustomValue5;
        public bool useLatestCustomValue6;
        public bool useLatestCustomValue7;
        public bool useLatestCustomValue8;
        public bool useLatestCustomValue9;
        public bool useLatestCustomValue10;

        public PurchaseIos(Purchase purchase)
        {
            this.customValue = purchase.getCustomValue();
            this.productIos = new ProductIos(purchase.getProduct());
            this.orderNo = purchase.getOrderNo();
            this.currency = purchase.getCurrency();
            this.keywordCategory = purchase.getKeywordCategory();
            this.keyword = purchase.getKeyword();

            this.useLatestSearchKeyword = purchase.getUseLatestSearchKeyword();
            this.useLatestCustomValue1 = purchase.getUseLatestCustomValue1();
            this.useLatestCustomValue2 = purchase.getUseLatestCustomValue2();
            this.useLatestCustomValue3 = purchase.getUseLatestCustomValue3();
            this.useLatestCustomValue4 = purchase.getUseLatestCustomValue4();
            this.useLatestCustomValue5 = purchase.getUseLatestCustomValue5();
            this.useLatestCustomValue6 = purchase.getUseLatestCustomValue6();
            this.useLatestCustomValue7 = purchase.getUseLatestCustomValue7();
            this.useLatestCustomValue8 = purchase.getUseLatestCustomValue8();
            this.useLatestCustomValue9 = purchase.getUseLatestCustomValue9();
            this.useLatestCustomValue10 = purchase.getUseLatestCustomValue10();

        }
    }

    public struct ClickIos
    {
        public CustomValue customValue;
        public ProductIos productIos;
        public string clickType;
        public string clickData;

        public ClickIos(Click click)
        {
            this.customValue = click.getCustomValue();
            this.productIos = new ProductIos(click.getProduct());
            this.clickType = click.getClickType();
            this.clickData = click.getClickData();
        }
    }

}
