//
//  PurchaseViewController.swift
//  SDKSample
//
//  Created by Green Shin on 2022/07/15.
//

import os
import UIKit
import DOT
import AdSupport

class PurchaseViewController: UIViewController {
  let logger = Logger(subsystem: Bundle.main.bundleIdentifier != nil ? Bundle.main.bundleIdentifier! : "Unknown" , category: "PurchaseViewController")
  
  override func viewWillAppear(_ animated: Bool) {
    super.viewWillAppear(animated)
    
    // 상품구매 완료 화면에 삽입하십시오
    // 예시는 상품을 2개 구매하는 경우입니다.
    let purchase = NSMutableDictionary()
    purchase["transaction_id"] = "TR2020111129421"
    purchase["currency"] = "KRW"
    
    var product1 : [String: Any] = [:]
    product1["product_id"] = "2007291158"
    product1["product_name"] = "Leia Pleats Bag Black"
    product1["quantity"] = 2
    product1["revenue"] = 566200
    
    var product2 : [String: Any] = [:]
    product2["product_id"] = "2005268849"
    product2["product_name"] = "페이 스몰 숄더백 (FAYE)"
    product2["quantity"] = 1
    product2["revenue"] = 1323000
    
    var productArray : [Any] = []
    productArray.append(product1)
    productArray.append(product2)
    
    purchase["product"] = productArray
    DOT.logPurchase(purchase)
    
    logger.debug("call DOT.logScreen() on viewWillAppear()")
  }
  
  override func viewDidAppear(_ animated: Bool) {
    super.viewDidAppear(animated)
    logger.debug("call showAtt() on viewDidAppear()")
  }
  
  override func viewDidLoad() {
    super.viewDidLoad()
    // Do any additional setup after loading the view.
    logger.debug("on viewDidLoad()")
  }

}
