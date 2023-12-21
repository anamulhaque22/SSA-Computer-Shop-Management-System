"use client";

import Image from "next/image";
import { useState } from "react";

const Checkout = () => {
  const BILLING_INFO_OBJ = {
    firstName: "",
    lastName: "",
    email: "",
    phone: "",
    address: "",
    city: "",
  };
  const [billingInfo, setBillingInfo] = useState(BILLING_INFO_OBJ);
  const [notes, setNotes] = useState([]);
  const updateInputValue = (e) => {
    const { name, value } = e.target;
    setBillingInfo((prev) => ({ ...prev, [name]: value }));
  };
  console.log(billingInfo);
  return (
    <div className="container my-7 flex gap-x-6">
      <div className="w-[70%]">
        <h1 className="text-lg font-medium">Shopping Cart</h1>
        <form action="">
          <div className="flex gap-5 mb-3">
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  First Name
                </span>
              </label>
              <input
                name="firstName"
                type="text"
                value={billingInfo.firstName}
                placeholder="First Name"
                onChange={updateInputValue}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  Last Name
                </span>
              </label>
              <input
                name="lastName"
                type="text"
                value={billingInfo.lastName}
                placeholder="Last Name"
                onChange={updateInputValue}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
          </div>
          <div className="flex gap-5 mb-3">
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  Address
                </span>
              </label>
              <input
                name="address"
                type="text"
                value={billingInfo.address}
                placeholder="Address"
                onChange={updateInputValue}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  City
                </span>
              </label>
              <input
                name="city"
                type="text"
                value={billingInfo.city}
                placeholder="City"
                onChange={updateInputValue}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
          </div>
          <div className="flex gap-5">
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  Email
                </span>
              </label>
              <input
                name="email"
                type="text"
                value={billingInfo.email}
                placeholder="Email"
                onChange={updateInputValue}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  Phone Number
                </span>
              </label>
              <input
                name="phone"
                type="text"
                value={billingInfo.phone}
                placeholder="Phone Number"
                onChange={updateInputValue}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
          </div>
        </form>

        <div className="mt-5">
          <h4 className="font-medium text-lg">
            Payment Option: <span className="text-sm">Cash on Delivery</span>
          </h4>
        </div>

        <div>
          <div className="form-control w-full">
            <label className="label">
              <span
                className={"font-causten-semi-bold text-base text-[#3C4242]"}
              >
                Order Notes (Optional)
              </span>
            </label>
            <textarea
              name="notes"
              value={notes}
              rows={3}
              placeholder="Notes about your order, e.g. special notes for delivery"
              onChange={(e) => setNotes(e.target.value)}
              className="input-bordered w-full focus:outline-none border p-3"
            />
          </div>
        </div>
      </div>

      <div className="w-[30%] ">
        <div className="rounded-sm border p-5">
          <h1 className="text-lg font-medium mb-5">Order Summery</h1>
          <div className="flex flex-col">
            <div className="flex items-center gap-x-4">
              <div className="w-[65px] h-[65px]">
                <Image
                  src="/images/asus.webp"
                  width={0}
                  height={0}
                  sizes="100vh"
                  className="w-full h-full"
                  alt="porduct"
                />
              </div>
              <div className="w-[calc(100%-65px)]">
                <h4 className="font-medium truncate">
                  Product Product NameProduct NameProduct Name Name
                </h4>
                <span className="text-sm">1 x $55</span>
              </div>
            </div>
          </div>
          <div className="flex justify-between">
            <span>Sub-total</span>
            <span>$70</span>
          </div>
          <div className="flex justify-between">
            <span>Discount</span>
            <span>$70</span>
          </div>
          <div className="divider"></div>
          <div className="flex justify-between font-semibold">
            <span>Total</span>
            <span>$70</span>
          </div>
          <button className="cbtn w-full py-3 mt-3 rounded-sm">
            Place Order
          </button>
        </div>
      </div>
    </div>
  );
};

export default Checkout;
