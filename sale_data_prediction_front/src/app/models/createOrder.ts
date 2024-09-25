import { Employees } from "./employees";
import { Product } from "./product";
import { salesDatePredictor } from "./salesDatePredictor";
import { Shippers } from "./shippers";

export class createOrder{
    constructor(
        public Customer: salesDatePredictor,
        public idEmployee: number,
        public idProduct: number,
        public idShipper: number,
        public OrderDate: Date ,
        public RequireDate: Date ,
        public ShippedDate: Date,
        public Freight: number,
        public Unitprice: number,
        public Qty: number ,
        public Discount: number,
    ){}
    
}