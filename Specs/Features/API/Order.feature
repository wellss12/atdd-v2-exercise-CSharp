Feature: Order

    @api-login
    @db
    Scenario: 订单列表
        Given 存在如下订单:
          | code  | productName | total | recipientName | status        |
          | SN001 | 电脑          | 19999 | 张三            | toBeDelivered |
        When API查询订单时
        Then 返回如下订单
        """
          [{
            "code": "SN001",
            "productName": "电脑",
            "total": 19999.00,
            "status": "toBeDelivered"
          }]
        """