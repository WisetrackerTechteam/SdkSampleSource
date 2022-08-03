using System;
using System.Collections.Generic;
using UnityEngine;

namespace DOT_Model
{

    public struct User
    {
        private string member;
        private string gender;
        private string age;
        private string attr1;
        private string attr2;
        private string attr3;
        private string attr4;
        private string attr5;
        private string memberGrade;
        private string memberId;
        private Boolean isLogin;

        public string getMember()
        {
            return member;
        }

        public string getGender()
        {
            return gender;
        }

        public string getAge()
        {
            return age;
        }

        public string getAttr1()
        {
            return attr1;
        }

        public string getAttr2()
        {
            return attr2;
        }

        public string getAttr3()
        {
            return attr3;
        }

        public string getAttr4()
        {
            return attr4;
        }

        public string getAttr5()
        {
            return attr5;
        }

        public string getMemberGrade()
        {
            return memberGrade;
        }

        public string getMemberId()
        {
            return memberId;
        }

        public Boolean getIsLogin()
        {
            return isLogin;
        }

        public User(Builder builder)
        {
            member = builder.member;
            gender = builder.gender;
            age = builder.age;
            attr1 = builder.attr1;
            attr2 = builder.attr2;
            attr3 = builder.attr3;
            attr4 = builder.attr4;
            attr5 = builder.attr5;
            memberGrade = builder.memberGrade;
            memberId = builder.memberId;
            isLogin = builder.isLogin;
        }

        public struct Builder
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

            public Builder setMember(string member)
            {
                this.member = member;
                return this;
            }

            public Builder setGender(string gender)
            {
                this.gender = gender;
                return this;
            }

            public Builder setAge(string age)
            {
                this.age = age;
                return this;
            }

            public Builder setAttr1(string attr1)
            {
                this.attr1 = attr1;
                return this;
            }

            public Builder setAttr2(string attr2)
            {
                this.attr2 = attr2;
                return this;
            }

            public Builder setAttr3(string attr3)
            {
                this.attr3 = attr3;
                return this;
            }

            public Builder setAttr4(string attr4)
            {
                this.attr4 = attr4;
                return this;
            }

            public Builder setAttr5(string attr5)
            {
                this.attr5 = attr5;
                return this;
            }

            public Builder setMemberGrade(string memberGrade)
            {
                this.memberGrade = memberGrade;
                return this;
            }

            public Builder setMemberId(string memberId)
            {
                this.memberId = memberId;
                return this;
            }

            public Builder setIsLogin(Boolean isLogin)
            {
                this.isLogin = isLogin;
                return this;
            }

            public User build()
            {
                this.isLogin = true;
                return new User(this);
            }

        }

    }

    public struct Page
    {

        private CustomValue customValue;
        private Product product;
        private string contentPath;
        private int searchResultCount;
        private string keywordCategory;
        private string keyword;
        private string identity;

        public CustomValue getCustomValue()
        {
            return customValue;
        }

        public Product getProduct()
        {
            return product;
        }

        public string getContentPath()
        {
            return contentPath;
        }

        public int getSearchResultCount()
        {
            return searchResultCount;
        }

        public string getKeywordCategory()
        {
            return keywordCategory;
        }

        public string getKeyword()
        {
            return keyword;
        }

        public string getIdentity()
        {
            return identity;
        }

        public Page(Builder builder)
        {
            customValue = builder.customValue;
            product = builder.product;
            contentPath = builder.contentPath;
            searchResultCount = builder.searchResultCount;
            keywordCategory = builder.keywordCategory;
            keyword = builder.keyword;
            identity = builder.identity;
        }

        public struct Builder
        {

            public CustomValue customValue;
            public Product product;
            public string contentPath;
            public int searchResultCount;
            public string keywordCategory;
            public string keyword;
            public string identity;

            public Builder setCustomValue(CustomValue customValue)
            {
                this.customValue = customValue;
                return this;
            }

            public Builder setProduct(Product product)
            {
                this.product = product;
                return this;
            }

            public Builder setContentPath(string contentPath)
            {
                this.contentPath = contentPath;
                return this;
            }

            public Builder setSearchResultCount(int searchResult)
            {
                this.searchResultCount = searchResult;
                return this;
            }

            public Builder setKeywordCategory(string keywordCategory)
            {
                this.keywordCategory = keywordCategory;
                return this;
            }

            public Builder setKeyword(string keyword)
            {
                this.keyword = keyword;
                return this;
            }

            public Builder setIdentity(string identity)
            {
                this.identity = identity;
                return this;
            }

            public Page build()
            {
                return new Page(this);
            }

        }

    }

    public struct Purchase
    {

        private CustomValue customValue;
        private List<Product> productList;
        private Product product;
        private string orderNo;
        private string currency;
        private string keywordCategory;
        private string keyword;

        private Boolean useLatestSearchKeyword;
        private Boolean useLatestCustomValue1;
        private Boolean useLatestCustomValue2;
        private Boolean useLatestCustomValue3;
        private Boolean useLatestCustomValue4;
        private Boolean useLatestCustomValue5;
        private Boolean useLatestCustomValue6;
        private Boolean useLatestCustomValue7;
        private Boolean useLatestCustomValue8;
        private Boolean useLatestCustomValue9;
        private Boolean useLatestCustomValue10;

        public CustomValue getCustomValue()
        {
            return customValue;
        }

        public Product getProduct()
        {
            return product;
        }

        public List<Product> getProductList()
        {
            return productList;
        }

        public string getOrderNo()
        {
            return orderNo;
        }

        public string getCurrency()
        {
            return currency;
        }

        public string getKeywordCategory()
        {
            return keywordCategory;
        }

        public string getKeyword()
        {
            return keyword;
        }

        public Boolean getUseLatestSearchKeyword()
        {
            return useLatestSearchKeyword;
        }

        public Boolean getUseLatestCustomValue1()
        {
            return useLatestCustomValue1;
        }

        public Boolean getUseLatestCustomValue2()
        {
            return useLatestCustomValue2;
        }

        public Boolean getUseLatestCustomValue3()
        {
            return useLatestCustomValue3;
        }

        public Boolean getUseLatestCustomValue4()
        {
            return useLatestCustomValue4;
        }

        public Boolean getUseLatestCustomValue5()
        {
            return useLatestCustomValue5;
        }

        public Boolean getUseLatestCustomValue6()
        {
            return useLatestCustomValue6;
        }

        public Boolean getUseLatestCustomValue7()
        {
            return useLatestCustomValue7;
        }

        public Boolean getUseLatestCustomValue8()
        {
            return useLatestCustomValue8;
        }

        public Boolean getUseLatestCustomValue9()
        {
            return useLatestCustomValue9;
        }

        public Boolean getUseLatestCustomValue10()
        {
            return useLatestCustomValue10;
        }

        public Purchase(Builder builder)
        {
            customValue = builder.customValue;
            productList = builder.productList;
            product = builder.product;
            orderNo = builder.orderNo;
            currency = builder.currency;
            keywordCategory = builder.keywordCategory;
            keyword = builder.keyword;
            useLatestSearchKeyword = builder.useLatestSearchKeyword;
            useLatestCustomValue1 = builder.useLatestCustomValue1;
            useLatestCustomValue2 = builder.useLatestCustomValue2;
            useLatestCustomValue3 = builder.useLatestCustomValue3;
            useLatestCustomValue4 = builder.useLatestCustomValue4;
            useLatestCustomValue5 = builder.useLatestCustomValue5;
            useLatestCustomValue6 = builder.useLatestCustomValue6;
            useLatestCustomValue7 = builder.useLatestCustomValue7;
            useLatestCustomValue8 = builder.useLatestCustomValue8;
            useLatestCustomValue9 = builder.useLatestCustomValue9;
            useLatestCustomValue10 = builder.useLatestCustomValue10;
        }

        public struct Builder
        {

            public CustomValue customValue;
            public List<Product> productList;
            public Product product;
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

            public Builder setCustomValue(CustomValue customValue)
            {
                this.customValue = customValue;
                return this;
            }

            public Builder setProductList(List<Product> productList)
            {
                this.productList = productList;
                return this;
            }

            public Builder setProduct(Product product)
            {
                if (productList == null)
                {
                    productList = new List<Product>();
                }
                productList.Add(product);
                this.product = product;
                return this;
            }

            public Builder setOrderNo(string orderNo)
            {
                this.orderNo = orderNo;
                return this;
            }

            public Builder setCurrency(string currency)
            {
                this.currency = currency;
                return this;
            }

            public Builder setKeywordCategory(string keywordCategory)
            {
                this.keywordCategory = keywordCategory;
                return this;
            }

            public Builder setKeyword(string keyword)
            {
                this.keyword = keyword;
                return this;
            }

            public Builder setUseLatestSearchKeyword()
            {
                this.useLatestSearchKeyword = true;
                return this;
            }

            public Builder setUseLatestCustomValue1()
            {
                this.useLatestCustomValue1 = true;
                return this;
            }

            public Builder setUseLatestCustomValue2()
            {
                this.useLatestCustomValue2 = true;
                return this;
            }

            public Builder setUseLatestCustomValue3()
            {
                this.useLatestCustomValue3 = true;
                return this;
            }

            public Builder setUseLatestCustomValue4()
            {
                this.useLatestCustomValue4 = true;
                return this;
            }

            public Builder setUseLatestCustomValue5()
            {
                this.useLatestCustomValue5 = true;
                return this;
            }

            public Builder setUseLatestCustomValue6()
            {
                this.useLatestCustomValue6 = true;
                return this;
            }

            public Builder setUseLatestCustomValue7()
            {
                this.useLatestCustomValue7 = true;
                return this;
            }

            public Builder setUseLatestCustomValue8()
            {
                this.useLatestCustomValue8 = true;
                return this;
            }

            public Builder setUseLatestCustomValue9()
            {
                this.useLatestCustomValue9 = true;
                return this;
            }

            public Builder setUseLatestCustomValue10()
            {
                this.useLatestCustomValue10 = true;
                return this;
            }

            public Purchase build()
            {
                return new Purchase(this);
            }

        }

    }

    public struct Conversion
    {
        private CustomValue customValue;
        private Product product;
        private string keywordCategory;
        private string keyword;
        private double microConversion1;
        private double microConversion2;
        private double microConversion3;
        private double microConversion4;
        private double microConversion5;
        private double microConversion6;
        private double microConversion7;
        private double microConversion8;
        private double microConversion9;
        private double microConversion10;
        private double microConversion11;
        private double microConversion12;
        private double microConversion13;
        private double microConversion14;
        private double microConversion15;
        private double microConversion16;
        private double microConversion17;
        private double microConversion18;
        private double microConversion19;
        private double microConversion20;
        private double microConversion21;
        private double microConversion22;
        private double microConversion23;
        private double microConversion24;
        private double microConversion25;
        private double microConversion26;
        private double microConversion27;
        private double microConversion28;
        private double microConversion29;
        private double microConversion30;
        private double microConversion31;
        private double microConversion32;
        private double microConversion33;
        private double microConversion34;
        private double microConversion35;
        private double microConversion36;
        private double microConversion37;
        private double microConversion38;
        private double microConversion39;
        private double microConversion40;
        private double microConversion41;
        private double microConversion42;
        private double microConversion43;
        private double microConversion44;
        private double microConversion45;
        private double microConversion46;
        private double microConversion47;
        private double microConversion48;
        private double microConversion49;
        private double microConversion50;
        private double microConversion51;
        private double microConversion52;
        private double microConversion53;
        private double microConversion54;
        private double microConversion55;
        private double microConversion56;
        private double microConversion57;
        private double microConversion58;
        private double microConversion59;
        private double microConversion60;
        private double microConversion61;
        private double microConversion62;
        private double microConversion63;
        private double microConversion64;
        private double microConversion65;
        private double microConversion66;
        private double microConversion67;
        private double microConversion68;
        private double microConversion69;
        private double microConversion70;
        private double microConversion71;
        private double microConversion72;
        private double microConversion73;
        private double microConversion74;
        private double microConversion75;
        private double microConversion76;
        private double microConversion77;
        private double microConversion78;
        private double microConversion79;
        private double microConversion80;
        private bool pushAgreement;

        public CustomValue getCustomValue()
        {
            return customValue;
        }

        public Product getProduct()
        {
            return product;
        }

        public string getKeywordCategory()
        {
            return keywordCategory;
        }

        public string getKeyword()
        {
            return keyword;
        }

        public double getMicroConversion1()
        {
            return microConversion1;
        }

        public double getMicroConversion2()
        {
            return microConversion2;
        }

        public double getMicroConversion3()
        {
            return microConversion3;
        }

        public double getMicroConversion4()
        {
            return microConversion4;
        }

        public double getMicroConversion5()
        {
            return microConversion5;
        }

        public double getMicroConversion6()
        {
            return microConversion6;
        }

        public double getMicroConversion7()
        {
            return microConversion7;
        }

        public double getMicroConversion8()
        {
            return microConversion8;
        }

        public double getMicroConversion9()
        {
            return microConversion9;
        }

        public double getMicroConversion10()
        {
            return microConversion10;
        }

        public double getMicroConversion11()
        {
            return microConversion11;
        }

        public double getMicroConversion12()
        {
            return microConversion12;
        }

        public double getMicroConversion13()
        {
            return microConversion13;
        }

        public double getMicroConversion14()
        {
            return microConversion14;
        }

        public double getMicroConversion15()
        {
            return microConversion15;
        }

        public double getMicroConversion16()
        {
            return microConversion16;
        }

        public double getMicroConversion17()
        {
            return microConversion17;
        }

        public double getMicroConversion18()
        {
            return microConversion18;
        }

        public double getMicroConversion19()
        {
            return microConversion19;
        }

        public double getMicroConversion20()
        {
            return microConversion20;
        }

        public double getMicroConversion21()
        {
            return microConversion21;
        }

        public double getMicroConversion22()
        {
            return microConversion22;
        }

        public double getMicroConversion23()
        {
            return microConversion23;
        }

        public double getMicroConversion24()
        {
            return microConversion24;
        }

        public double getMicroConversion25()
        {
            return microConversion25;
        }

        public double getMicroConversion26()
        {
            return microConversion26;
        }

        public double getMicroConversion27()
        {
            return microConversion27;
        }

        public double getMicroConversion28()
        {
            return microConversion28;
        }

        public double getMicroConversion29()
        {
            return microConversion29;
        }

        public double getMicroConversion30()
        {
            return microConversion30;
        }

        public double getMicroConversion31()
        {
            return microConversion31;
        }

        public double getMicroConversion32()
        {
            return microConversion32;
        }

        public double getMicroConversion33()
        {
            return microConversion33;
        }

        public double getMicroConversion34()
        {
            return microConversion34;
        }

        public double getMicroConversion35()
        {
            return microConversion35;
        }

        public double getMicroConversion36()
        {
            return microConversion36;
        }

        public double getMicroConversion37()
        {
            return microConversion37;
        }

        public double getMicroConversion38()
        {
            return microConversion38;
        }

        public double getMicroConversion39()
        {
            return microConversion39;
        }

        public double getMicroConversion40()
        {
            return microConversion40;
        }

        public double getMicroConversion41()
        {
            return microConversion41;
        }

        public double getMicroConversion42()
        {
            return microConversion42;
        }

        public double getMicroConversion43()
        {
            return microConversion43;
        }

        public double getMicroConversion44()
        {
            return microConversion44;
        }

        public double getMicroConversion45()
        {
            return microConversion45;
        }

        public double getMicroConversion46()
        {
            return microConversion46;
        }

        public double getMicroConversion47()
        {
            return microConversion47;
        }

        public double getMicroConversion48()
        {
            return microConversion48;
        }

        public double getMicroConversion49()
        {
            return microConversion49;
        }

        public double getMicroConversion50()
        {
            return microConversion50;
        }

        public double getMicroConversion51()
        {
            return microConversion51;
        }

        public double getMicroConversion52()
        {
            return microConversion52;
        }

        public double getMicroConversion53()
        {
            return microConversion53;
        }

        public double getMicroConversion54()
        {
            return microConversion54;
        }

        public double getMicroConversion55()
        {
            return microConversion55;
        }

        public double getMicroConversion56()
        {
            return microConversion56;
        }

        public double getMicroConversion57()
        {
            return microConversion57;
        }

        public double getMicroConversion58()
        {
            return microConversion58;
        }

        public double getMicroConversion59()
        {
            return microConversion59;
        }

        public double getMicroConversion60()
        {
            return microConversion60;
        }

        public double getMicroConversion61()
        {
            return microConversion61;
        }

        public double getMicroConversion62()
        {
            return microConversion62;
        }

        public double getMicroConversion63()
        {
            return microConversion63;
        }

        public double getMicroConversion64()
        {
            return microConversion64;
        }

        public double getMicroConversion65()
        {
            return microConversion65;
        }

        public double getMicroConversion66()
        {
            return microConversion66;
        }

        public double getMicroConversion67()
        {
            return microConversion67;
        }

        public double getMicroConversion68()
        {
            return microConversion68;
        }

        public double getMicroConversion69()
        {
            return microConversion69;
        }

        public double getMicroConversion70()
        {
            return microConversion70;
        }

        public double getMicroConversion71()
        {
            return microConversion71;
        }

        public double getMicroConversion72()
        {
            return microConversion72;
        }

        public double getMicroConversion73()
        {
            return microConversion73;
        }

        public double getMicroConversion74()
        {
            return microConversion74;
        }

        public double getMicroConversion75()
        {
            return microConversion75;
        }

        public double getMicroConversion76()
        {
            return microConversion76;
        }

        public double getMicroConversion77()
        {
            return microConversion77;
        }

        public double getMicroConversion78()
        {
            return microConversion78;
        }

        public double getMicroConversion79()
        {
            return microConversion79;
        }

        public double getMicroConversion80()
        {
            return microConversion80;
        }

        public bool getPushAgreement()
        {
            return pushAgreement;
        }

        public Conversion(Builder builder)
        {
            customValue = builder.customValue;
            product = builder.product;
            keyword = builder.keyword;
            keywordCategory = builder.keywordCategory;
            microConversion1 = builder.microConversion1;
            microConversion2 = builder.microConversion2;
            microConversion3 = builder.microConversion3;
            microConversion4 = builder.microConversion4;
            microConversion5 = builder.microConversion5;
            microConversion6 = builder.microConversion6;
            microConversion7 = builder.microConversion7;
            microConversion8 = builder.microConversion8;
            microConversion9 = builder.microConversion9;
            microConversion10 = builder.microConversion10;
            microConversion11 = builder.microConversion11;
            microConversion12 = builder.microConversion12;
            microConversion13 = builder.microConversion13;
            microConversion14 = builder.microConversion14;
            microConversion15 = builder.microConversion15;
            microConversion16 = builder.microConversion16;
            microConversion17 = builder.microConversion17;
            microConversion18 = builder.microConversion18;
            microConversion19 = builder.microConversion19;
            microConversion20 = builder.microConversion20;
            microConversion21 = builder.microConversion21;
            microConversion22 = builder.microConversion22;
            microConversion23 = builder.microConversion23;
            microConversion24 = builder.microConversion24;
            microConversion25 = builder.microConversion25;
            microConversion26 = builder.microConversion26;
            microConversion27 = builder.microConversion27;
            microConversion28 = builder.microConversion28;
            microConversion29 = builder.microConversion29;
            microConversion30 = builder.microConversion30;
            microConversion31 = builder.microConversion31;
            microConversion32 = builder.microConversion32;
            microConversion33 = builder.microConversion33;
            microConversion34 = builder.microConversion34;
            microConversion35 = builder.microConversion35;
            microConversion36 = builder.microConversion36;
            microConversion37 = builder.microConversion37;
            microConversion38 = builder.microConversion38;
            microConversion39 = builder.microConversion39;
            microConversion40 = builder.microConversion40;
            microConversion41 = builder.microConversion41;
            microConversion42 = builder.microConversion42;
            microConversion43 = builder.microConversion43;
            microConversion44 = builder.microConversion44;
            microConversion45 = builder.microConversion45;
            microConversion46 = builder.microConversion46;
            microConversion47 = builder.microConversion47;
            microConversion48 = builder.microConversion48;
            microConversion49 = builder.microConversion49;
            microConversion50 = builder.microConversion50;
            microConversion51 = builder.microConversion51;
            microConversion52 = builder.microConversion52;
            microConversion53 = builder.microConversion53;
            microConversion54 = builder.microConversion54;
            microConversion55 = builder.microConversion55;
            microConversion56 = builder.microConversion56;
            microConversion57 = builder.microConversion57;
            microConversion58 = builder.microConversion58;
            microConversion59 = builder.microConversion59;
            microConversion60 = builder.microConversion60;
            microConversion61 = builder.microConversion61;
            microConversion62 = builder.microConversion62;
            microConversion63 = builder.microConversion63;
            microConversion64 = builder.microConversion64;
            microConversion65 = builder.microConversion65;
            microConversion66 = builder.microConversion66;
            microConversion67 = builder.microConversion67;
            microConversion68 = builder.microConversion68;
            microConversion69 = builder.microConversion69;
            microConversion70 = builder.microConversion70;
            microConversion71 = builder.microConversion71;
            microConversion72 = builder.microConversion72;
            microConversion73 = builder.microConversion73;
            microConversion74 = builder.microConversion74;
            microConversion75 = builder.microConversion75;
            microConversion76 = builder.microConversion76;
            microConversion77 = builder.microConversion77;
            microConversion78 = builder.microConversion78;
            microConversion79 = builder.microConversion79;
            microConversion80 = builder.microConversion80;
            pushAgreement = builder.pushAgreement;
        }

        public struct Builder
        {

            public CustomValue customValue;
            public Product product;
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
            public Boolean pushAgreement;

            public Builder setCustomValue(CustomValue customValue)
            {
                this.customValue = customValue;
                return this;
            }

            public Builder setProduct(Product product)
            {
                this.product = product;
                return this;
            }

            public Builder setKeywordCategory(string keywordCategory)
            {
                this.keywordCategory = keywordCategory;
                return this;
            }

            public Builder setKeyword(string keyword)
            {
                this.keyword = keyword;
                return this;
            }

            public Builder setMicroConversion1(double microConversion1)
            {
                this.microConversion1 = microConversion1;
                return this;
            }

            public Builder setMicroConversion2(double microConversion2)
            {
                this.microConversion2 = microConversion2;
                return this;
            }

            public Builder setMicroConversion3(double microConversion3)
            {
                this.microConversion3 = microConversion3;
                return this;
            }

            public Builder setMicroConversion4(double microConversion4)
            {
                this.microConversion4 = microConversion4;
                return this;
            }

            public Builder setMicroConversion5(double microConversion5)
            {
                this.microConversion5 = microConversion5;
                return this;
            }

            public Builder setMicroConversion6(double microConversion6)
            {
                this.microConversion6 = microConversion6;
                return this;
            }

            public Builder setMicroConversion7(double microConversion7)
            {
                this.microConversion7 = microConversion7;
                return this;
            }

            public Builder setMicroConversion8(double microConversion8)
            {
                this.microConversion8 = microConversion8;
                return this;
            }

            public Builder setMicroConversion9(double microConversion9)
            {
                this.microConversion9 = microConversion9;
                return this;
            }

            public Builder setMicroConversion10(double microConversion10)
            {
                this.microConversion10 = microConversion10;
                return this;
            }

            public Builder setMicroConversion11(double microConversion11)
            {
                this.microConversion11 = microConversion11;
                return this;
            }

            public Builder setMicroConversion12(double microConversion12)
            {
                this.microConversion12 = microConversion12;
                return this;
            }

            public Builder setMicroConversion13(double microConversion13)
            {
                this.microConversion13 = microConversion13;
                return this;
            }

            public Builder setMicroConversion14(double microConversion14)
            {
                this.microConversion14 = microConversion14;
                return this;
            }

            public Builder setMicroConversion15(double microConversion15)
            {
                this.microConversion15 = microConversion15;
                return this;
            }

            public Builder setMicroConversion16(double microConversion16)
            {
                this.microConversion16 = microConversion16;
                return this;
            }

            public Builder setMicroConversion17(double microConversion17)
            {
                this.microConversion17 = microConversion17;
                return this;
            }

            public Builder setMicroConversion18(double microConversion18)
            {
                this.microConversion18 = microConversion18;
                return this;
            }

            public Builder setMicroConversion19(double microConversion19)
            {
                this.microConversion19 = microConversion19;
                return this;
            }

            public Builder setMicroConversion20(double microConversion20)
            {
                this.microConversion20 = microConversion20;
                return this;
            }

            public Builder setMicroConversion21(double microConversion21)
            {
                this.microConversion21 = microConversion21;
                return this;
            }

            public Builder setMicroConversion22(double microConversion22)
            {
                this.microConversion22 = microConversion22;
                return this;
            }

            public Builder setMicroConversion23(double microConversion23)
            {
                this.microConversion23 = microConversion23;
                return this;
            }

            public Builder setMicroConversion24(double microConversion24)
            {
                this.microConversion24 = microConversion24;
                return this;
            }

            public Builder setMicroConversion25(double microConversion25)
            {
                this.microConversion25 = microConversion25;
                return this;
            }

            public Builder setMicroConversion26(double microConversion26)
            {
                this.microConversion26 = microConversion26;
                return this;
            }

            public Builder setMicroConversion27(double microConversion27)
            {
                this.microConversion27 = microConversion27;
                return this;
            }

            public Builder setMicroConversion28(double microConversion28)
            {
                this.microConversion28 = microConversion28;
                return this;
            }

            public Builder setMicroConversion29(double microConversion29)
            {
                this.microConversion29 = microConversion29;
                return this;
            }

            public Builder setMicroConversion30(double microConversion30)
            {
                this.microConversion30 = microConversion30;
                return this;
            }

            public Builder setMicroConversion31(double microConversion31)
            {
                this.microConversion31 = microConversion31;
                return this;
            }

            public Builder setMicroConversion32(double microConversion32)
            {
                this.microConversion32 = microConversion32;
                return this;
            }

            public Builder setMicroConversion33(double microConversion33)
            {
                this.microConversion33 = microConversion33;
                return this;
            }

            public Builder setMicroConversion34(double microConversion34)
            {
                this.microConversion34 = microConversion34;
                return this;
            }

            public Builder setMicroConversion35(double microConversion35)
            {
                this.microConversion35 = microConversion35;
                return this;
            }

            public Builder setMicroConversion36(double microConversion36)
            {
                this.microConversion36 = microConversion36;
                return this;
            }

            public Builder setMicroConversion37(double microConversion37)
            {
                this.microConversion37 = microConversion37;
                return this;
            }

            public Builder setMicroConversion38(double microConversion38)
            {
                this.microConversion38 = microConversion38;
                return this;
            }

            public Builder setMicroConversion39(double microConversion39)
            {
                this.microConversion39 = microConversion39;
                return this;
            }

            public Builder setMicroConversion40(double microConversion40)
            {
                this.microConversion40 = microConversion40;
                return this;
            }

            public Builder setMicroConversion41(double microConversion41)
            {
                this.microConversion41 = microConversion41;
                return this;
            }

            public Builder setMicroConversion42(double microConversion42)
            {
                this.microConversion42 = microConversion42;
                return this;
            }

            public Builder setMicroConversion43(double microConversion43)
            {
                this.microConversion43 = microConversion43;
                return this;
            }

            public Builder setMicroConversion44(double microConversion44)
            {
                this.microConversion44 = microConversion44;
                return this;
            }

            public Builder setMicroConversion45(double microConversion45)
            {
                this.microConversion45 = microConversion45;
                return this;
            }

            public Builder setMicroConversion46(double microConversion46)
            {
                this.microConversion46 = microConversion46;
                return this;
            }

            public Builder setMicroConversion47(double microConversion47)
            {
                this.microConversion47 = microConversion47;
                return this;
            }

            public Builder setMicroConversion48(double microConversion48)
            {
                this.microConversion48 = microConversion48;
                return this;
            }

            public Builder setMicroConversion49(double microConversion49)
            {
                this.microConversion49 = microConversion49;
                return this;
            }

            public Builder setMicroConversion50(double microConversion50)
            {
                this.microConversion50 = microConversion50;
                return this;
            }

            public Builder setMicroConversion51(double microConversion51)
            {
                this.microConversion51 = microConversion51;
                return this;
            }

            public Builder setMicroConversion52(double microConversion52)
            {
                this.microConversion52 = microConversion52;
                return this;
            }

            public Builder setMicroConversion53(double microConversion53)
            {
                this.microConversion53 = microConversion53;
                return this;
            }

            public Builder setMicroConversion54(double microConversion54)
            {
                this.microConversion54 = microConversion54;
                return this;
            }

            public Builder setMicroConversion55(double microConversion55)
            {
                this.microConversion55 = microConversion55;
                return this;
            }

            public Builder setMicroConversion56(double microConversion56)
            {
                this.microConversion56 = microConversion56;
                return this;
            }

            public Builder setMicroConversion57(double microConversion57)
            {
                this.microConversion57 = microConversion57;
                return this;
            }

            public Builder setMicroConversion58(double microConversion58)
            {
                this.microConversion58 = microConversion58;
                return this;
            }

            public Builder setMicroConversion59(double microConversion59)
            {
                this.microConversion59 = microConversion59;
                return this;
            }

            public Builder setMicroConversion60(double microConversion60)
            {
                this.microConversion60 = microConversion60;
                return this;
            }

            public Builder setMicroConversion61(double microConversion61)
            {
                this.microConversion61 = microConversion61;
                return this;
            }

            public Builder setMicroConversion62(double microConversion62)
            {
                this.microConversion62 = microConversion62;
                return this;
            }

            public Builder setMicroConversion63(double microConversion63)
            {
                this.microConversion63 = microConversion63;
                return this;
            }

            public Builder setMicroConversion64(double microConversion64)
            {
                this.microConversion64 = microConversion64;
                return this;
            }

            public Builder setMicroConversion65(double microConversion65)
            {
                this.microConversion65 = microConversion65;
                return this;
            }

            public Builder setMicroConversion66(double microConversion66)
            {
                this.microConversion66 = microConversion66;
                return this;
            }

            public Builder setMicroConversion67(double microConversion67)
            {
                this.microConversion67 = microConversion67;
                return this;
            }

            public Builder setMicroConversion68(double microConversion68)
            {
                this.microConversion68 = microConversion68;
                return this;
            }

            public Builder setMicroConversion69(double microConversion69)
            {
                this.microConversion69 = microConversion69;
                return this;
            }

            public Builder setMicroConversion70(double microConversion70)
            {
                this.microConversion70 = microConversion70;
                return this;
            }

            public Builder setMicroConversion71(double microConversion71)
            {
                this.microConversion71 = microConversion71;
                return this;
            }

            public Builder setMicroConversion72(double microConversion72)
            {
                this.microConversion72 = microConversion72;
                return this;
            }

            public Builder setMicroConversion73(double microConversion73)
            {
                this.microConversion73 = microConversion73;
                return this;
            }

            public Builder setMicroConversion74(double microConversion74)
            {
                this.microConversion74 = microConversion74;
                return this;
            }

            public Builder setMicroConversion75(double microConversion75)
            {
                this.microConversion75 = microConversion75;
                return this;
            }

            public Builder setMicroConversion76(double microConversion76)
            {
                this.microConversion76 = microConversion76;
                return this;
            }

            public Builder setMicroConversion77(double microConversion77)
            {
                this.microConversion77 = microConversion77;
                return this;
            }

            public Builder setMicroConversion78(double microConversion78)
            {
                this.microConversion78 = microConversion78;
                return this;
            }

            public Builder setMicroConversion79(double microConversion79)
            {
                this.microConversion79 = microConversion79;
                return this;
            }

            public Builder setMicroConversion80(double microConversion80)
            {
                this.microConversion80 = microConversion80;
                return this;
            }

            public Builder setIsPush(bool isPush)
            {
                this.pushAgreement = isPush;
                return this;
            }

            public Conversion build()
            {
                return new Conversion(this);
            }

        }

    }

    public struct Click
    {

        private CustomValue customValue;
        private List<Product> productList;
        private Product product;
        private string clickType;
        private string clickData;

        public CustomValue getCustomValue()
        {
            return customValue;
        }

        public string getClickType()
        {
            return clickType;
        }

        public string getClickData()
        {
            return clickData;
        }

        public Product getProduct()
        {
            return product;
        }

        public List<Product> getProductList()
        {
            return productList;
        }

        public Click(Builder builder)
        {
            customValue = builder.customValue;
            product = builder.product;
            productList = builder.productList;
            clickType = builder.clickType;
            clickData = builder.clickData;
        }

        public struct Builder
        {
            public CustomValue customValue;
            public List<Product> productList;
            public Product product;
            public string clickType;
            public string clickData;


            public Builder setCustomValue(CustomValue customValue)
            {
                this.customValue = customValue;
                return this;
            }

            public Builder setClickEvent(string clickData)
            {
                this.clickType = "CKC";
                this.clickData = clickData;
                return this;
            }

            public Builder setSearchClickEvent(string clickData)
            {
                this.clickType = "SCH";
                this.clickData = clickData;
                return this;
            }

            public Builder setPushClickEvent(string clickData)
            {
                this.clickType = "PSH";
                this.clickData = clickData;
                return this;
            }

            public Builder addCartProduct(Product product)
            {
                this.clickType = "SCRT";
                if (productList == null)
                {
                    productList = new List<Product>();
                }
                this.productList.Add(product);
                this.product = product;
                return this;
            }

            public Builder addCartProductList(List<Product> productList)
            {
                this.clickType = "SCRT";
                this.productList = productList;
                return this;
            }

            public Click build()
            {
                return new Click(this);
            }

        }

    }

    public struct Product
    {

        private string firstCategory;
        private string secondCategory;
        private string thirdCategory;
        private string detailCategory;
        private string productCode;
        private string attr1;
        private string attr2;
        private string attr3;
        private string attr4;
        private string attr5;
        private string attr6;
        private string attr7;
        private string attr8;
        private string attr9;
        private string attr10;
        private string productOrderNo;
        private double orderAmount;
        private int orderQuantity;
        private double refundAmount;
        private int refundQuantity;
        public Dictionary<string, double> optionalAmount;

        public string getFirstCategory()
        {
            return firstCategory;
        }

        public string getSecondCategory()
        {
            return secondCategory;
        }

        public string getThirdCategory()
        {
            return thirdCategory;
        }

        public string getDetailCategory()
        {
            return detailCategory;
        }

        public string getProductCode()
        {
            return productCode;
        }

        public string getAttr1()
        {
            return attr1;
        }

        public string getAttr2()
        {
            return attr2;
        }

        public string getAttr3()
        {
            return attr3;
        }

        public string getAttr4()
        {
            return attr4;
        }

        public string getAttr5()
        {
            return attr5;
        }

        public string getAttr6()
        {
            return attr6;
        }

        public string getAttr7()
        {
            return attr7;
        }

        public string getAttr8()
        {
            return attr8;
        }

        public string getAttr9()
        {
            return attr9;
        }

        public string getAttr10()
        {
            return attr10;
        }

        public string getProductOrderNo()
        {
            return productOrderNo;
        }

        public double getOrderAmount()
        {
            return orderAmount;
        }

        public int getOrderQuantity()
        {
            return orderQuantity;
        }

        public double getRefundAmount()
        {
            return refundAmount;
        }

        public int getRefundQuantity()
        {
            return refundQuantity;
        }

        public Dictionary<string, double> getOptionalAmount()
        {
            return optionalAmount;
        }

        public Product(Builder builder)
        {
            firstCategory = builder.firstCategory;
            secondCategory = builder.secondCategory;
            thirdCategory = builder.thirdCategory;
            detailCategory = builder.detailCategory;
            productCode = builder.productCode;
            attr1 = builder.attr1;
            attr2 = builder.attr2;
            attr3 = builder.attr3;
            attr4 = builder.attr4;
            attr5 = builder.attr5;
            attr6 = builder.attr6;
            attr7 = builder.attr7;
            attr8 = builder.attr8;
            attr9 = builder.attr9;
            attr10 = builder.attr10;
            productOrderNo = builder.productOrderNo;
            orderAmount = builder.orderAmount;
            orderQuantity = builder.orderQuantity;
            refundAmount = builder.refundAmount;
            refundQuantity = builder.refundQuantity;
            optionalAmount = builder.optionalAmount;

        }

        public struct Builder
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
            public Dictionary<string, double> optionalAmount;

            public Builder setFirstCategory(string firstCategory)
            {
                this.firstCategory = firstCategory;
                return this;
            }

            public Builder setSecondCategory(string secondCategory)
            {
                this.secondCategory = secondCategory;
                return this;
            }

            public Builder setThirdCategory(string thirdCategory)
            {
                this.thirdCategory = thirdCategory;
                return this;
            }

            public Builder setDetailCategory(string detailCategory)
            {
                this.detailCategory = detailCategory;
                return this;
            }

            public Builder setProductCode(string productCode)
            {
                this.productCode = productCode;
                return this;
            }

            public Builder setAttr1(string attr1)
            {
                this.attr1 = attr1;
                return this;
            }

            public Builder setAttr2(string attr2)
            {
                this.attr2 = attr2;
                return this;
            }

            public Builder setAttr3(string attr3)
            {
                this.attr3 = attr3;
                return this;
            }

            public Builder setAttr4(string attr4)
            {
                this.attr4 = attr4;
                return this;
            }

            public Builder setAttr5(string attr5)
            {
                this.attr5 = attr5;
                return this;
            }

            public Builder setAttr6(string attr6)
            {
                this.attr6 = attr6;
                return this;
            }

            public Builder setAttr7(string attr7)
            {
                this.attr7 = attr7;
                return this;
            }

            public Builder setAttr8(string attr8)
            {
                this.attr8 = attr8;
                return this;
            }

            public Builder setAttr9(string attr9)
            {
                this.attr9 = attr9;
                return this;
            }

            public Builder setAttr10(string attr10)
            {
                this.attr10 = attr10;
                return this;
            }

            public Builder setProductOrderNo(string productOrderNo)
            {
                this.productOrderNo = productOrderNo;
                return this;
            }

            public Builder setOrderAmount(double orderAmount)
            {
                this.orderAmount = orderAmount;
                return this;
            }

            public Builder setOrderQuantity(int orderQuantity)
            {
                this.orderQuantity = orderQuantity;
                return this;
            }

            public Builder setRefundAmount(double refundAmount)
            {
                this.refundAmount = refundAmount;
                return this;
            }

            public Builder setRefundQuantity(int refundQuantity)
            {
                this.refundQuantity = refundQuantity;
                return this;
            }

            public Builder setOptionalAmount(string key, double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(key, value);

                return this;
            }

            public Builder setOptionalAmount1(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g1, value);
                return this;
            }

            public Builder setOptionalAmount2(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g2, value);
                return this;
            }

            public Builder setOptionalAmount3(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g3, value);
                return this;
            }

            public Builder setOptionalAmount4(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g4, value);
                return this;
            }

            public Builder setOptionalAmount5(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g5, value);
                return this;
            }

            public Builder setOptionalAmount6(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g6, value);
                return this;
            }

            public Builder setOptionalAmount7(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g7, value);
                return this;
            }

            public Builder setOptionalAmount8(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g8, value);
                return this;
            }

            public Builder setOptionalAmount9(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g9, value);
                return this;
            }

            public Builder setOptionalAmount10(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g10, value);
                return this;
            }

            public Builder setOptionalAmount11(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g11, value);
                return this;
            }

            public Builder setOptionalAmount12(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g12, value);
                return this;
            }

            public Builder setOptionalAmount13(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g13, value);
                return this;
            }

            public Builder setOptionalAmount14(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g14, value);
                return this;
            }

            public Builder setOptionalAmount15(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g15, value);
                return this;
            }

            public Builder setOptionalAmount16(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g16, value);
                return this;
            }

            public Builder setOptionalAmount17(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g17, value);
                return this;
            }

            public Builder setOptionalAmount18(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g18, value);
                return this;
            }

            public Builder setOptionalAmount19(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g19, value);
                return this;
            }

            public Builder setOptionalAmount20(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g20, value);
                return this;
            }

            public Builder setOptionalAmount21(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g21, value);
                return this;
            }

            public Builder setOptionalAmount22(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g22, value);
                return this;
            }

            public Builder setOptionalAmount23(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g23, value);
                return this;
            }

            public Builder setOptionalAmount24(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g24, value);
                return this;
            }

            public Builder setOptionalAmount25(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g25, value);
                return this;
            }

            public Builder setOptionalAmount26(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g26, value);
                return this;
            }

            public Builder setOptionalAmount27(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g27, value);
                return this;
            }

            public Builder setOptionalAmount28(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g28, value);
                return this;
            }

            public Builder setOptionalAmount29(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g29, value);
                return this;
            }

            public Builder setOptionalAmount30(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g30, value);
                return this;
            }

            public Builder setOptionalAmount31(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g31, value);
                return this;
            }

            public Builder setOptionalAmount32(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g32, value);
                return this;
            }

            public Builder setOptionalAmount33(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g33, value);
                return this;
            }

            public Builder setOptionalAmount34(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g34, value);
                return this;
            }

            public Builder setOptionalAmount35(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g35, value);
                return this;
            }

            public Builder setOptionalAmount36(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g36, value);
                return this;
            }

            public Builder setOptionalAmount37(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g37, value);
                return this;
            }

            public Builder setOptionalAmount38(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g38, value);
                return this;
            }

            public Builder setOptionalAmount39(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g39, value);
                return this;
            }

            public Builder setOptionalAmount40(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g40, value);
                return this;
            }

            public Builder setOptionalAmount41(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g41, value);
                return this;
            }

            public Builder setOptionalAmount42(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g42, value);
                return this;
            }

            public Builder setOptionalAmount43(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g43, value);
                return this;
            }

            public Builder setOptionalAmount44(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g44, value);
                return this;
            }

            public Builder setOptionalAmount45(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g45, value);
                return this;
            }

            public Builder setOptionalAmount46(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g46, value);
                return this;
            }

            public Builder setOptionalAmount47(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g47, value);
                return this;
            }

            public Builder setOptionalAmount48(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g48, value);
                return this;
            }

            public Builder setOptionalAmount49(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g49, value);
                return this;
            }

            public Builder setOptionalAmount50(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g50, value);
                return this;
            }

            public Builder setOptionalAmount51(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g51, value);
                return this;
            }

            public Builder setOptionalAmount52(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g52, value);
                return this;
            }

            public Builder setOptionalAmount53(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g53, value);
                return this;
            }

            public Builder setOptionalAmount54(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g54, value);
                return this;
            }

            public Builder setOptionalAmount55(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g55, value);
                return this;
            }

            public Builder setOptionalAmount56(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g56, value);
                return this;
            }

            public Builder setOptionalAmount57(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g57, value);
                return this;
            }

            public Builder setOptionalAmount58(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g58, value);
                return this;
            }

            public Builder setOptionalAmount59(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g59, value);
                return this;
            }

            public Builder setOptionalAmount60(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g60, value);
                return this;
            }

            public Builder setOptionalAmount61(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g61, value);
                return this;
            }

            public Builder setOptionalAmount62(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g62, value);
                return this;
            }

            public Builder setOptionalAmount63(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g63, value);
                return this;
            }

            public Builder setOptionalAmount64(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g64, value);
                return this;
            }

            public Builder setOptionalAmount65(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g65, value);
                return this;
            }

            public Builder setOptionalAmount66(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g66, value);
                return this;
            }

            public Builder setOptionalAmount67(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g67, value);
                return this;
            }

            public Builder setOptionalAmount68(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g68, value);
                return this;
            }

            public Builder setOptionalAmount69(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g69, value);
                return this;
            }

            public Builder setOptionalAmount70(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g70, value);
                return this;
            }

            public Builder setOptionalAmount71(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g71, value);
                return this;
            }

            public Builder setOptionalAmount72(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g72, value);
                return this;
            }

            public Builder setOptionalAmount73(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g73, value);
                return this;
            }

            public Builder setOptionalAmount74(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g74, value);
                return this;
            }

            public Builder setOptionalAmount75(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g75, value);
                return this;
            }

            public Builder setOptionalAmount76(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g76, value);
                return this;
            }

            public Builder setOptionalAmount77(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g77, value);
                return this;
            }

            public Builder setOptionalAmount78(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g78, value);
                return this;
            }

            public Builder setOptionalAmount79(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g79, value);
                return this;
            }

            public Builder setOptionalAmount80(double value)
            {
                if (this.optionalAmount == null)
                {
                    this.optionalAmount = new Dictionary<string, double>();
                }
                this.optionalAmount.Add(KEY.g80, value);
                return this;
            }

            public Product build()
            {
                return new Product(this);
            }

        }

    }

    public struct CustomValue
    {
        private string value1;
        private string value2;
        private string value3;
        private string value4;
        private string value5;
        private string value6;
        private string value7;
        private string value8;
        private string value9;
        private string value10;

        public string getValue1()
        {
            return value1;
        }

        public string getValue2()
        {
            return value2;
        }

        public string getValue3()
        {
            return value3;
        }

        public string getValue4()
        {
            return value4;
        }

        public string getValue5()
        {
            return value5;
        }

        public string getValue6()
        {
            return value6;
        }

        public string getValue7()
        {
            return value7;
        }

        public string getValue8()
        {
            return value8;
        }

        public string getValue9()
        {
            return value9;
        }

        public string getValue10()
        {
            return value10;
        }

        public CustomValue(Builder builder)
        {
            value1 = builder.value1;
            value2 = builder.value2;
            value3 = builder.value3;
            value4 = builder.value4;
            value5 = builder.value5;
            value6 = builder.value6;
            value7 = builder.value7;
            value8 = builder.value8;
            value9 = builder.value9;
            value10 = builder.value10;
        }

        public struct Builder
        {
            public string value1;
            public string value2;
            public string value3;
            public string value4;
            public string value5;
            public string value6;
            public string value7;
            public string value8;
            public string value9;
            public string value10;

            public Builder setValue1(string value1)
            {
                this.value1 = value1;
                return this;
            }

            public Builder setValue2(string value2)
            {
                this.value2 = value2;
                return this;
            }

            public Builder setValue3(string value3)
            {
                this.value3 = value3;
                return this;
            }

            public Builder setValue4(string value4)
            {
                this.value4 = value4;
                return this;
            }

            public Builder setValue5(string value5)
            {
                this.value5 = value5;
                return this;
            }

            public Builder setValue6(string value6)
            {
                this.value6 = value6;
                return this;
            }

            public Builder setValue7(string value7)
            {
                this.value7 = value7;
                return this;
            }

            public Builder setValue8(string value8)
            {
                this.value8 = value8;
                return this;
            }

            public Builder setValue9(string value9)
            {
                this.value9 = value9;
                return this;
            }

            public Builder setValue10(string value10)
            {
                this.value10 = value10;
                return this;
            }

            public CustomValue build()
            {
                return new CustomValue(this);
            }
        }

    }

    public struct KEY
    {

        public static string g1 = "g1";
        public static string g2 = "g2";
        public static string g3 = "g3";
        public static string g4 = "g4";
        public static string g5 = "g5";
        public static string g6 = "g6";
        public static string g7 = "g7";
        public static string g8 = "g8";
        public static string g9 = "g9";
        public static string g10 = "g10";
        public static string g11 = "g11";
        public static string g12 = "g12";
        public static string g13 = "g13";
        public static string g14 = "g14";
        public static string g15 = "g15";
        public static string g16 = "g16";
        public static string g17 = "g17";
        public static string g18 = "g18";
        public static string g19 = "g19";
        public static string g20 = "g20";
        public static string g21 = "g21";
        public static string g22 = "g22";
        public static string g23 = "g23";
        public static string g24 = "g24";
        public static string g25 = "g25";
        public static string g26 = "g26";
        public static string g27 = "g27";
        public static string g28 = "g28";
        public static string g29 = "g29";
        public static string g30 = "g30";
        public static string g31 = "g31";
        public static string g32 = "g32";
        public static string g33 = "g33";
        public static string g34 = "g34";
        public static string g35 = "g35";
        public static string g36 = "g36";
        public static string g37 = "g37";
        public static string g38 = "g38";
        public static string g39 = "g39";
        public static string g40 = "g40";
        public static string g41 = "g41";
        public static string g42 = "g42";
        public static string g43 = "g43";
        public static string g44 = "g44";
        public static string g45 = "g45";
        public static string g46 = "g46";
        public static string g47 = "g47";
        public static string g48 = "g48";
        public static string g49 = "g49";
        public static string g50 = "g50";
        public static string g51 = "g51";
        public static string g52 = "g52";
        public static string g53 = "g53";
        public static string g54 = "g54";
        public static string g55 = "g55";
        public static string g56 = "g56";
        public static string g57 = "g57";
        public static string g58 = "g58";
        public static string g59 = "g59";
        public static string g60 = "g60";
        public static string g61 = "g61";
        public static string g62 = "g62";
        public static string g63 = "g63";
        public static string g64 = "g64";
        public static string g65 = "g65";
        public static string g66 = "g66";
        public static string g67 = "g67";
        public static string g68 = "g68";
        public static string g69 = "g69";
        public static string g70 = "g70";
        public static string g71 = "g71";
        public static string g72 = "g72";
        public static string g73 = "g73";
        public static string g74 = "g74";
        public static string g75 = "g75";
        public static string g76 = "g76";
        public static string g77 = "g77";
        public static string g78 = "g78";
        public static string g79 = "g79";
        public static string g80 = "g80";

    }

}