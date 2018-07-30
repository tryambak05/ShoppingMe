using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using Contract;
using AutoMapper;

namespace ShoppingMe.Controllers
{
    public class CustomerController : BaseApiController
    {
        private CustomerRepository customerRepository;
        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }

        [HttpGet]
        [Route("api/v1/getcustomerbyid")]
        public IHttpActionResult GetCustomerById(int customerId)
        {
            if (customerId <= 0)
            {
                return GetResult<string>("Customer id should not be null.", HttpStatusCode.BadRequest);
            }

            var response = customerRepository.Get(customerId);
            if (response != null)
            {
                return GetResult<CustomerContract>(ToCustomerContract(response), HttpStatusCode.OK);
            }

            return GetResult<string>("Requested customer id dosen't not found.", HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("api/v1/getcustomerbyemail")]
        public IHttpActionResult GetCustomerByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return GetResult<string>("email id should not be null or empty.", HttpStatusCode.BadRequest);
            }

            var response = customerRepository.GetByEmail(email);

            if (response != null)
            {
                return GetResult<CustomerContract>(ToCustomerContract(response), HttpStatusCode.OK);
            }

            return GetResult<string>("Requested email id does not found.", HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("api/v1/validatecredentialbyemailandpassword")]
        public IHttpActionResult ValidateCredentialByEmailAndPassword(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return GetResult<string>(null, HttpStatusCode.BadRequest);
            }

            var response = customerRepository.ValidateCredentialByEmailAndPassword(email, password);
            if (response != null)
            {
                return GetResult<CustomerContract>(ToCustomerContract(response), HttpStatusCode.OK);
            }
            else
            {
                return GetResult<string>(null, HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("api/v1/createcustomer")]
        public IHttpActionResult CreateCustomer([FromBody]CustomerContract customerContract)
        {
            if (customerContract == null)
            {
                return GetResult<string>("Request is not valid. Please check parameter.", HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(customerContract.FirstName))
            {
                return GetResult<string>("Please check first name.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.LastName))
            {
                return GetResult<string>("Please check last name.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.Mobile))
            {
                return GetResult<string>("Please check mobile.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.Email))
            {
                return GetResult<string>("Please check email.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.Password))
            {
                return GetResult<string>("Please check password.", HttpStatusCode.BadRequest);
            }

            var isMobileNumberValid = customerContract.Mobile.All(char.IsDigit);

            if (isMobileNumberValid == false)
            {
                return GetResult<bool>(false, HttpStatusCode.BadRequest);
            }

            var customer = ToCustomer(customerContract);
            customer.FirstName = customer.FirstName;
            var response = customerRepository.Add(customer);
            if (response)
            {
                return GetResult<bool>(response, HttpStatusCode.OK);
            }

            return GetResult<string>("Requested customer doesn't added", HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("api/v1/updatecustomer")]
        public IHttpActionResult UpdateCustomer([FromBody]CustomerContract customerContract)
        {
            if (customerContract == null)
            {
                return GetResult<string>("Request is not valid. Please check parameter.", HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(customerContract.FirstName))
            {
                return GetResult<string>("Please check first name.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.LastName))
            {
                return GetResult<string>("Please check last name.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.Mobile))
            {
                return GetResult<string>("Please check mobile.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.Email))
            {
                return GetResult<string>("Please check email.", HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(customerContract.Password))
            {
                return GetResult<string>("Please check password.", HttpStatusCode.BadRequest);
            }

            var customer = ToCustomer(customerContract);
            var response = customerRepository.Update(customer);
            if (response)
            {
                return GetResult<bool>(response, HttpStatusCode.OK);
            }

            return GetResult<bool>(response, HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("api/v1/deletecustomerbyid")]
        public IHttpActionResult DeleteCustomer(int customerId)
        {
            if (customerId <= 0)
            {
                return GetResult<string>("Customer id should not be null.", HttpStatusCode.BadRequest);
            }

            var response = customerRepository.Delete(customerId);
            if (response)
            {
                return GetResult<bool>(response, HttpStatusCode.OK);
            }
            else
            {
                return GetResult<bool>(response, HttpStatusCode.BadRequest);
            }
        }
 
        internal Customer ToCustomer(CustomerContract customerContract)
        {
            Customer customer = new Customer();
            customer.CustomerId = customerContract.CustomerId;
            customer.FirstName = customerContract.FirstName;
            customer.LastName = customerContract.LastName;
            customer.Mobile = customerContract.Mobile;
            customer.Password = customerContract.Password;
            customer.Email = customerContract.Email;
            customer.CreatedDate = customerContract.CreatedDate;
            customer.ModifiedDate = customerContract.ModifiedDate;

            return customer;
        }

        internal CustomerContract ToCustomerContract(Customer customer)
        {
            CustomerContract customerContract = new CustomerContract();
            customerContract.CustomerId = customer.CustomerId;
            customerContract.FirstName = customer.FirstName;
            customerContract.LastName = customer.LastName;
            customerContract.Mobile = customer.Mobile;
            customerContract.Password = customer.Password;
            customerContract.Email = customer.Email;
            customerContract.CreatedDate = customer.CreatedDate;
            customerContract.ModifiedDate = customer.ModifiedDate;

            return customerContract;
        }
    }
}
