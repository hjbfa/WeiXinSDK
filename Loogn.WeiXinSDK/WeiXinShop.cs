﻿using System;
using System.Collections.Generic;
using System.Text;
using Loogn.WeiXinSDK.Shop;

namespace Loogn.WeiXinSDK
{
    /// <summary>
    /// 微信小店
    /// </summary>
    public class WeiXinShop
    {

        #region 商品管理接口

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="product"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static AddProductResult AddProduct(Product product, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/create?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(product));
            return Util.JsonTo<AddProductResult>(json);
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static AddProductResult AddProduct(Product product)
        {
            WeiXin.CheckGlobalCredential();
            return AddProduct(product, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="product_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode DeleteProduct(string product_id, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/del?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { product_id = product_id }));
            return Util.JsonTo<ReturnCode>(json);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public static ReturnCode DeleteProduct(string product_id)
        {
            WeiXin.CheckGlobalCredential();
            return DeleteProduct(product_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 修改商品信息
        /// 从未商家的商品所有信息均可修改，否则商品的名称、商品分类、商品属性这三个字段不可修改
        /// </summary>
        /// <param name="product"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode UpdateProduct(Product product, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/update?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(product));
            return Util.JsonTo<ReturnCode>(json);
        }

        /// <summary>
        /// 修改商品信息
        /// 从未商家的商品所有信息均可修改，否则商品的名称、商品分类、商品属性这三个字段不可修改
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ReturnCode UpdateProduct(Product product)
        {
            WeiXin.CheckGlobalCredential();
            return UpdateProduct(product, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="product_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetProductResult GetProduct(string product_id,string appId,string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/get?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { product_id = product_id }));
            return Util.JsonTo<GetProductResult>(json);
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public static GetProductResult GetProduct(string product_id)
        {
            WeiXin.CheckGlobalCredential();
            return GetProduct(product_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// status：0全部，1上架，2下架
        /// </summary>
        /// <param name="status"></param>
        public static GetProductListResult GetProductListByStatus(byte status, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/getbystatus?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { status = status }));
            return Util.JsonTo<GetProductListResult>(json);
        }
        /// <summary>
        /// status：0全部，1上架，2下架
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static GetProductListResult GetProductListByStatus(byte status)
        {
            WeiXin.CheckGlobalCredential();
            return GetProductListByStatus(status, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 商品上下架
        /// </summary>
        /// <param name="product_id">商品id</param>
        /// <param name="status">0下架，1上架</param>
        /// <returns></returns>
        public static ReturnCode SetProductStatus(string product_id, byte status, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/modproductstatus?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { product_id = product_id, status = status }));
            return Util.JsonTo<ReturnCode>(json);
        }

        /// <summary>
        /// 商品上下架
        /// </summary>
        /// <param name="product_id">商品id</param>
        /// <param name="status">0下架，1上架</param>
        /// <returns></returns>
        public static ReturnCode SetProductStatus(string product_id, byte status)
        {
            WeiXin.CheckGlobalCredential();
            return SetProductStatus(product_id, status, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 获取指定分类的所有子分类
        /// </summary>
        /// <param name="cate_id">大分类id(根节点分类id为1)</param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetSubCateListResult GetSubCateList(string cate_id,string appId, string appSecret) 
        { 
            var url = "https://api.weixin.qq.com/merchant/category/getsub?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { cate_id = cate_id }));
            return Util.JsonTo<GetSubCateListResult>(json);
        }
        /// <summary>
        /// 获取指定分类的所有子分类
        /// </summary>
        /// <param name="cate_id">大分类id(根节点分类id为1)</param>
        /// <returns></returns>
        public static GetSubCateListResult GetSubCateList(string cate_id)
        {
            WeiXin.CheckGlobalCredential();
            return GetSubCateList(cate_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 获取制定子分类的所有sku
        /// </summary>
        /// <param name="cate_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetSKUListResult GetSKUListBySubCate(string cate_id, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/category/getsku?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { cate_id = cate_id }));
            return Util.JsonTo<GetSKUListResult>(json);
        }

        /// <summary>
        /// 获取制定子分类的所有sku
        /// </summary>
        /// <param name="cate_id"></param>
        /// <returns></returns>
        public static GetSKUListResult GetSKUListBySubCate(string cate_id)
        {
            WeiXin.CheckGlobalCredential();
            return GetSKUListBySubCate(cate_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 获取指定分类的所有属性
        /// </summary>
        /// <param name="cate_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetPropertyListResult GetPropertyListByCate(string cate_id, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/category/getproperty?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { cate_id = cate_id }));
            return Util.JsonTo<GetPropertyListResult>(json);       
        }
        /// <summary>
        /// 获取指定分类的所有属性
        /// </summary>
        /// <param name="cate_id"></param>
        /// <returns></returns>
        public static GetPropertyListResult GetPropertyListByCate(string cate_id)
        {
            WeiXin.CheckGlobalCredential();
            return GetPropertyListByCate(cate_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        #endregion

        #region 库存管理接口

        /// <summary>
        /// 增加库存
        /// </summary>
        /// <param name="product_id">商品id</param>
        /// <param name="sku_info">sku信息，格式"id1:vid1;id2:vid2",
        /// 如商品为统一规格，则此处赋值为空字符串即可</param>
        /// <param name="quantity">增加库存的数量</param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode AddStock(string product_id, string sku_info, int quantity, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/stock/add?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { product_id = product_id, sku_info = sku_info, quantity = quantity }));
            return Util.JsonTo<ReturnCode>(json);
        }

        /// <summary>
        /// 增加库存
        /// </summary>
        /// <param name="product_id">商品id</param>
        /// <param name="sku_info">sku信息，格式"id1:vid1;id2:vid2",
        /// 如商品为统一规格，则此处赋值为空字符串即可</param>
        /// <param name="quantity">增加库存的数量</param>
        /// <returns></returns>
        public static ReturnCode AddStock(string product_id, string sku_info, int quantity)
        {
            WeiXin.CheckGlobalCredential();
            return AddStock(product_id, sku_info, quantity, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 减少库存
        /// </summary>
        /// <param name="product_id">商品id</param>
        /// <param name="sku_info">sku信息，格式"id1:vid1;id2:vid2",
        /// 如商品为统一规格，则此处赋值为空字符串即可</param>
        /// <param name="quantity">减少库存的数量</param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode ReduceStock(string product_id, string sku_info, int quantity, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/stock/reduce?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { product_id = product_id, sku_info = sku_info, quantity = quantity }));
            return Util.JsonTo<ReturnCode>(json);
        }

        /// <summary>
        /// 减少库存
        /// </summary>
        /// <param name="product_id">商品id</param>
        /// <param name="sku_info">sku信息，格式"id1:vid1;id2:vid2",
        /// 如商品为统一规格，则此处赋值为空字符串即可</param>
        /// <param name="quantity">减少库存的数量</param>
        /// <returns></returns>
        public static ReturnCode ReduceStock(string product_id, string sku_info, int quantity)
        {
            WeiXin.CheckGlobalCredential();
            return ReduceStock(product_id, sku_info, quantity, WeiXin.AppID, WeiXin.AppSecret);
        }

        #endregion

        #region 邮费模板管理接口

        /// <summary>
        /// 添加邮费模板
        /// </summary>
        /// <param name="delivery_template"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static AddDeliveryTemplateResult AddDeliveryTemplate(DeliveryTemplate delivery_template, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/express/add?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { delivery_template = delivery_template }));
            return Util.JsonTo<AddDeliveryTemplateResult>(json);
        }

        /// <summary>
        /// 添加邮费模板
        /// </summary>
        /// <param name="delivery_template"></param>
        /// <returns></returns>
        public static AddDeliveryTemplateResult AddDeliveryTemplate(DeliveryTemplate delivery_template)
        {
            WeiXin.CheckGlobalCredential();
            return AddDeliveryTemplate(delivery_template, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 删除邮费模板
        /// </summary>
        /// <param name="template_id">邮费模板id</param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode DeleteDeliveryTemplate(long template_id, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/express/del?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { template_id = template_id }));
            return Util.JsonTo<ReturnCode>(json);
        }
        /// <summary>
        /// 删除邮费模板
        /// </summary>
        /// <param name="template_id">邮费模板id</param>
        /// <returns></returns>
        public static ReturnCode DeleteDeliveryTemplate(long template_id)
        {
            WeiXin.CheckGlobalCredential();
            return DeleteDeliveryTemplate(template_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 删除邮费模板
        /// </summary>
        /// <param name="delivery_template"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode UpdateDeliveryTemplate(DeliveryTemplate delivery_template, string appId, string appSecret)
        {
            var template_id = delivery_template.Id;
            var url = "https://api.weixin.qq.com/merchant/express/update?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { template_id = template_id, delivery_template = delivery_template }));
            return Util.JsonTo<ReturnCode>(json);
        }
        /// <summary>
        /// 删除邮费模板
        /// </summary>
        /// <param name="delivery_template"></param>
        /// <returns></returns>
        public static ReturnCode UpdateDeliveryTemplate(DeliveryTemplate delivery_template)
        {
            WeiXin.CheckGlobalCredential();
            return UpdateDeliveryTemplate(delivery_template, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 获取指定id的邮费模板
        /// </summary>
        /// <param name="template_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetDeliveryTemplateResult GetDeliveryTemplate(long template_id, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/express/getbyid?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { template_id = template_id }));
            return Util.JsonTo<GetDeliveryTemplateResult>(json);
        }

        /// <summary>
        /// 获取指定id的邮费模板
        /// </summary>
        /// <param name="template_id"></param>
        /// <returns></returns>
        public static GetDeliveryTemplateResult GetDeliveryTemplate(long template_id)
        {
            WeiXin.CheckGlobalCredential();
            return GetDeliveryTemplate(template_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 获取所有邮费模板
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetDeliveryTemplateListResult GetDeliveryTemplateList(string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/express/getall?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpGet2(url);
            return Util.JsonTo<GetDeliveryTemplateListResult>(json);
        }

        /// <summary>
        /// 获取所有邮费模板
        /// </summary>
        /// <returns></returns>
        public static GetDeliveryTemplateListResult GetDeliveryTemplateList()
        {
            WeiXin.CheckGlobalCredential();
            return GetDeliveryTemplateList(WeiXin.AppID, WeiXin.AppSecret);
        }



        #endregion

        #region 分组管理接口
        /// <summary>
        /// 增加分组
        /// </summary>
        /// <param name="group_detail"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static AddGroupResult AddGroup(Group group_detail, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/group/add?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { group_detail = group_detail }));
            return Util.JsonTo<AddGroupResult>(json);
        }
        /// <summary>
        /// 增加分组
        /// </summary>
        /// <param name="group_detail"></param>
        /// <returns></returns>
        public static AddGroupResult AddGroup(Group group_detail)
        {
            WeiXin.CheckGlobalCredential();
            return AddGroup(group_detail,WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="group_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode DeleteGroup(long group_id, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/group/del?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { group_id = group_id }));
            return Util.JsonTo<ReturnCode>(json);
        }
        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public static ReturnCode DeleteGroup(long group_id)
        {
            WeiXin.CheckGlobalCredential();
            return DeleteGroup(group_id, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 修改分组属性
        /// </summary>
        /// <param name="group"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode UpdateGroupProperty(Group group, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/group/propertymod?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(group));
            return Util.JsonTo<ReturnCode>(json);
        }
        /// <summary>
        /// 修改分组属性
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static ReturnCode UpdateGroupProperty(Group group)
        {
            WeiXin.CheckGlobalCredential();
            return UpdateGroupProperty(group, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 修改分组商品
        /// </summary>
        /// <param name="group"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static ReturnCode UpdateProductGroup(UpdateGroupProduct group, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/group/productmod?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(group));
            return Util.JsonTo<ReturnCode>(json);
        }
        /// <summary>
        /// 修改分组商品
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static ReturnCode UpdateProductGroup(UpdateGroupProduct group)
        {
            WeiXin.CheckGlobalCredential();
            return UpdateProductGroup(group, WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 获取所有分组
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetGroupListResult GetGroupList(string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/group/getall?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpGet2(url);
            return Util.JsonTo<GetGroupListResult>(json);
        }
        /// <summary>
        /// 获取所有分组
        /// </summary>
        /// <returns></returns>
        public static GetGroupListResult GetGroupList()
        {
            WeiXin.CheckGlobalCredential();
            return GetGroupList(WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// 根据分组id获取分组信息
        /// </summary>
        /// <param name="group_id"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetGroupResult GetGroup(long group_id, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/group/getbyid?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token;
            var json = Util.HttpPost2(url, Util.ToJson(new { group_id = group_id }));
            return Util.JsonTo<GetGroupResult>(json);
        }

        /// <summary>
        /// 根据分组id获取分组信息
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public static GetGroupResult GetGroup(long group_id)
        {
            WeiXin.CheckGlobalCredential();
            return GetGroup(group_id,WeiXin.AppID, WeiXin.AppSecret);
        }

        #endregion

        #region 货架管理接口

        public static void AddShelf() { }

        public static void DeleteShelf() { }

        public static void UpdateShelf() { }

        public static void GetShelfList() { }

        public static void GetShelf() { }

        public static void SetShelfStatus() { }

        #endregion

        #region 订单管理接口

        public static void GetOrder() { } //根据id

        public static void GetOrder(int a) { } //根据订单状态、创建时间

        public static void SetOrderDelivery() { }

        public static void CloseOrder() { }

        #endregion

        #region 功能接口
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="filename">图片文件名（带文件类型后缀）</param>
        /// <param name="data">图片数据</param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static UploadImgResult UploadImg(string filename, byte[] data, string appId, string appSecret)
        {
            var url = "https://api.weixin.qq.com/merchant/common/upload_img?access_token=";
            var access_token = WeiXin.GetAccessToken(appId, appSecret);
            url = url + access_token + "filename=" + filename;
            var json = Util.HttpPost2(url, data);
            return Util.JsonTo<UploadImgResult>(json);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="filename">图片文件名（带文件类型后缀）</param>
        /// <param name="data">图片数据</param>
        /// <returns></returns>
        public static UploadImgResult UploadImg(string filename, byte[] data)
        {
            WeiXin.CheckGlobalCredential();
            return UploadImg(filename, data, WeiXin.AppID, WeiXin.AppSecret);
        }

        #endregion

    }
}
