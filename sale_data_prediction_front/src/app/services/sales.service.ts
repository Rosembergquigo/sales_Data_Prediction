import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { salesDatePredictor } from '../models/salesDatePredictor';
import { getCustomerOrders } from '../models/getCustomerOrder';
import { Employees } from '../models/employees';
import { Shippers } from '../models/shippers';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class SalesService {
  myApiUrl = "https://localhost:44376/api/";
  
  list: salesDatePredictor[] = [];
  ordersCust : getCustomerOrders[] = [];
  customerName: string = "";
  listEmployees: Employees[] = [];
  listShippers: Shippers[] = [];
  listProduct: Product[]=[];
  constructor( private http: HttpClient) { }

  getSalesDatePredictor(){
    this.http.get(this.myApiUrl + "order").toPromise()
    .then(data =>{
      this.list = data as salesDatePredictor[];
    })
  }
  getCustomerOrders(id: number){
    this.http.get(this.myApiUrl + "customer/order/" + id).toPromise()
    .then(data => {
      this.ordersCust = data as getCustomerOrders[];
    })
  }
  getEmployees(){
    this.http.get(this.myApiUrl + "employee").toPromise()
    .then(data => {
      this.listEmployees = data as Employees[];
    });
  }

  getShippers(){
    this.http.get(this.myApiUrl + "shipper").toPromise()
    .then(data => {
      this.listShippers = data as Shippers[];
    });
  }

  getProducts(){
    this.http.get(this.myApiUrl + "product").toPromise()
    .then(data => {
      this.listProduct = data as Product[];
    });
  }
}
