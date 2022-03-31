﻿using MateriaGris.Ecommerce.Application.Commons;
using MateriaGris.Ecommerce.Application.Dtos;
using MateriaGris.Ecommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MateriaGris.Ecommerce.Infrastructure;
using AutoMapper;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using MateriaGris.Ecommerce.Domain.Entities;

namespace MateriaGris.Ecommerce.Application.Services
{
    class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerRepository _customerRepository;
        //Mapear objetos entre capas
        private readonly IMapper _mapper;

        //Inyectar la dependencia por costructor
        public CustomerApplication(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = await _customerRepository.GetAllAsync();
                if (customers is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<CustomerDto>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = await _customerRepository.GetAsync(customerId);
                if (customer is not null) {
                    response.Data = _mapper.Map<CustomerDto>(customer);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }
                
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> InsertAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerRepository.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!";
                }
                else {
                    response.Message = "Registro Fallido";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerRepository.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitosa!!";
                }
                else
                {
                    response.Message = "Actualizacion Fallida!!";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                
                response.Data = await _customerRepository.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion Exitosa!!";
                }
                else
                {
                    response.Message = "Actualizacion fallido";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }

            return response;
        }
    }
}
