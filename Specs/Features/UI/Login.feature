Feature: Login

    Scenario: 登录成功
        Given 存在用户名为"joseph"和密码为"123"的用户
        When 以用户名为"joseph"和密码为"123"登录时
        Then "joseph"登录成功

    Scenario: 登录失败
        Given 存在用户名为"joseph"和密码为"123"的用户
        When 以用户名为"joseph"和密码为"incorrect-password"登录时
        Then 登录失败的错误信息是"无效的用户名或密码"