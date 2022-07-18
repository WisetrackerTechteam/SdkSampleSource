//
//  ProductViewController.swift
//  SDKSample
//
//  Created by Green Shin on 2022/07/15.
//

import os
import UIKit
import DOT
import AdSupport
import SnackBar_swift

class ProductViewController: UIViewController {
  let logger = Logger(subsystem: Bundle.main.bundleIdentifier != nil ? Bundle.main.bundleIdentifier! : "Unknown" , category: "ProductViewController")
  
  @IBOutlet weak var buttonAddToCart: UIButton!
  
  override func viewWillAppear(_ animated: Bool) {
    super.viewWillAppear(animated)
    
    // 상품 상세 화면에 삽입하십시오
    let screen = NSMutableDictionary()
    screen["event"] = "w_view_product"
    var product : [String: Any] = [:]
    product["product_id"] = "2007291158"
    product["product_name"] = "Leia Pleats Bag Black"
    screen["product"] = product
    DOT.logScreen(screen)

    logger.debug("call DOT.logScreen() on viewWillAppear()")
  }
  
  override func viewDidAppear(_ animated: Bool) {
    super.viewDidAppear(animated)
    logger.debug("call showAtt() on viewDidAppear()")
  }
  
  override func viewDidLoad() {
    super.viewDidLoad()
    
    // Do any additional setup after loading the view.
    
    // 장바구니 추가 이벤트 처리
    buttonAddToCart.addTarget(self, action: #selector(handleAddToCart(_:)), for: .touchUpInside)
    
    logger.debug("on viewDidLoad()")
  }

  @objc
  private func handleAddToCart(_ sender: UIButton) {
    // 상품이 장바구니에 추가되는 시점에 삽입하십시오
    // 예시는 상품이 2개 담기는 경우입니다.
    let event = NSMutableDictionary()
    event["event"] = "w_add_to_cart"
    
    var product1 : [String: Any] = [:]
    product1["product_id"] = "2007291158"
    product1["product_name"] = "Leia Pleats Bag Black"
    product1["quantity"] = 2
    
    var product2 : [String: Any] = [:]
    product2["product_id"] = "2005268849"
    product2["product_name"] = "페이 스몰 숄더백 (FAYE)"
    product2["quantity"] = 1
    
    var product : [Any] = []
    product.append(product1)
    product.append(product2)
    
    event["product"] = product
    
    DOT.logEvent(event)
    
    SnackBar.make(in: self.view, message: "상품이 장바구니에 담겼어요", duration: .lengthLong).show()

    logger.debug("상품이 장바구니에 담겼어요.")
  }

}
