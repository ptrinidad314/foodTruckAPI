using foodTruckAPI.Data.Models;
using foodTruckAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Services
{
    public class OrderRepository : IOrderRepository
    {
        const decimal _SALES_TAX = 0.08M;

        public CreateOrderResultDTO CreateOrder(OrderDTO orderDTO)
        {
            try
            {
                CreateOrderResultDTO createOrderResultDTO = new CreateOrderResultDTO();

                using (var db = new sakilaContext()) 
                {

                    //get customer
                    Ftcustomer existingCustomer = db.Ftcustomer.Where(c => c.Email == orderDTO.email).FirstOrDefault();
                    if (existingCustomer == null) 
                    {
                        //create customer
                        existingCustomer = CreateFTCustomer(orderDTO);
                    }


                    //create payment
                    Ftpayment ftpayment = CreateFTPayment(orderDTO, existingCustomer.Ftcustomerid);

                    if (orderDTO.paymentmethodtype == 1)
                    {
                        //create credit card
                    }
                    else 
                    {
                        //create paypal
                    }

                    //create order 
                    Order orderToCreate = CreateOrder(ftpayment.Ftpaymentid, orderDTO.note);

                    //create order menu list
                    CreateOrderMenuList(orderToCreate.OrderId, orderDTO.menuItems);

                    createOrderResultDTO.orderId = orderToCreate.OrderId;

                    return createOrderResultDTO;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
        
        private Ftcustomer CreateFTCustomer(OrderDTO orderDTO) 
        {
            try
            {
                using (var db = new sakilaContext()) 
                {
                    Ftcustomer customerToCreate = new Ftcustomer();
                    customerToCreate.Email = orderDTO.email;
                    customerToCreate.Firstname = orderDTO.firstname;
                    customerToCreate.Lastname = orderDTO.lastname;
                    customerToCreate.Phone = int.Parse(orderDTO.phone.Remove('-'));

                    Ftaddress billingAddress = CreateFTAddress(orderDTO.billing_address);
                    customerToCreate.Ftaddressidbilling = billingAddress.Ftaddressid;

                    if (orderDTO.billing_address_sameAs_shipping_address)
                    {
                        customerToCreate.Ftaddressidshipping = billingAddress.Ftaddressid;
                    }
                    else 
                    {
                        Ftaddress shippingAddress = CreateFTAddress(orderDTO.shipping_address);
                        customerToCreate.Ftaddressidshipping = shippingAddress.Ftaddressid;
                    }

                    db.Ftcustomer.Add(customerToCreate);

                    db.SaveChanges();

                    return customerToCreate;

                }
            }
            catch (Exception ex) 
            {
                return null;
            }
            
        }

        private Ftaddress CreateFTAddress(AddressDTO addressDTO) 
        {
            try
            {
                using (var db = new sakilaContext()) 
                {
                    Ftaddress ftaddress = new Ftaddress();
                    ftaddress.Line1 = addressDTO.addressline1;
                    ftaddress.Line2 = addressDTO.addressline2;
                    ftaddress.Stateid = addressDTO.stateid;
                    ftaddress.Unitnumber = addressDTO.unitnumber;
                    ftaddress.Zipcode = addressDTO.zipcode;

                    db.Ftaddress.Add(ftaddress);
                    db.SaveChanges();

                    return ftaddress;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        private Ftpayment CreateFTPayment(OrderDTO orderDTO, long Ftcustomerid) 
        {
            try
            {
                using (var db = new sakilaContext()) 
                {
                    Ftpayment ftpayment = new Ftpayment();
                    ftpayment.Ftcustomerid = Ftcustomerid;
                    ftpayment.Ftpaymentamount = GetOrderTotal(orderDTO.menuItems);
                    ftpayment.Ftpaymentcomplete = 0;
                    ftpayment.Ftpaymenttypeid = orderDTO.paymentmethodtype;

                    db.Ftpayment.Add(ftpayment);

                    db.SaveChanges();

                    return ftpayment;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        private Decimal GetOrderTotal(List<long> menuItemIds) 
        {
            try
            {
                decimal orderTotal = 0.0M;

                using (var db = new sakilaContext()) 
                {
                    foreach (var mId in menuItemIds) 
                    {
                        Menu menuItem = db.Menu.Where(m => m.Menuid == mId).FirstOrDefault();

                        if (menuItem != null) 
                        {
                            orderTotal = orderTotal + menuItem.Price;
                        }

                        orderTotal = orderTotal + (orderTotal * _SALES_TAX); 
                    }

                    return orderTotal;
                }
            }
            catch (Exception ex) 
            {
                return 0.0M;
            }
        }

        private Order CreateOrder(long ftPaymentid, string orderNote) 
        {
            try
            {
                using (var db = new sakilaContext()) 
                {
                    Order orderToCreate = new Order();
                    orderToCreate.PaymentInfoId = ftPaymentid;
                    orderToCreate.Note = orderNote;

                    db.Order.Add(orderToCreate);

                    db.SaveChanges();

                    return orderToCreate;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        private void CreateOrderMenuList(long orderId, List<long> menuIds) 
        {
            try
            {
                using (var db = new sakilaContext()) 
                {
                    foreach (long mId in menuIds) 
                    {
                        Ordermenu om = new Ordermenu();

                        om.Orderid = orderId;
                        om.Menuid = mId;

                        db.Ordermenu.Add(om);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                
            }
            
        }
    }
}
