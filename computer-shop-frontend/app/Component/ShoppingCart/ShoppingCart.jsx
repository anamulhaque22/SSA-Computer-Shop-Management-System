"use client";
import React, { useState } from "react";

const ShoppingCart = () => {
  const [quantity, setQuantity] = useState(1); // [1, function
  const handleQuantityIncrease = () => {
    setQuantity(quantity + 1);
  };
  const handleQuantityDecrease = () => {
    if (quantity > 1) {
      setQuantity(quantity - 1);
    }
  };
  const handleOnChange = (e) => {
    const value = parseInt(e.target.value);
    if (value > 0) {
      setQuantity(value);
    }
  };
  return (
    <div className="container my-7 flex gap-x-6">
      <div className="w-[70%]">
        <h1 className="text-lg font-medium border p-5">Shopping Cart</h1>
        <table className="table table-zebra">
          {/* head */}
          <thead className="bg-[#F2F4F5] text-[#475156] border border-t-0">
            <tr>
              <th>Products</th>
              <th>Price</th>
              <th>Quantity</th>
              <th>Sub-Total</th>
            </tr>
          </thead>
          <tbody className="border-l border-r">
            {/* row 1 */}
            <tr>
              <th>
                <div className="flex items-center">
                  <span className="flex justify-center items-center w-[25px] h-[25px] text-xs rounded-full border text-[#929FA5] border-[#929FA5] cursor-pointer hover:text-primary hover:border-primary">
                    X
                  </span>
                  <img
                    src="/images/Image.png"
                    alt="product"
                    className="w-[72px] h-auto object-cover rounded"
                  />
                  <h4 className="text-base font-normal">
                    4K UHD LED Smart TV with Chromecast Built-in
                  </h4>
                </div>
              </th>
              <td className="text-[#475156]">$70</td>
              <td>
                <div className="flex increase-decrease-btn">
                  <button
                    className="border border-r-0 pl-5"
                    onClick={handleQuantityDecrease}
                  >
                    -
                  </button>
                  <input
                    type="number"
                    value={quantity}
                    onChange={handleOnChange}
                    onClick={(e) => e.target.select()}
                    className="input input-bordered border-l-0 border-r-0 w-24 rounded-none"
                  />
                  <button
                    className="border border-l-0 pr-5"
                    onClick={handleQuantityIncrease}
                  >
                    +
                  </button>
                </div>
              </td>
              <td className="text-[#475156]">$70</td>
            </tr>
          </tbody>
        </table>
        <div className="border border-t-0 py-4 px-5 text-right">
          <button className="cbtn px-3 py-2">Update Cart</button>
        </div>
      </div>

      <div className="w-[30%] ">
        <div className="rounded-sm border p-5">
          <h1 className="text-lg font-medium mb-5">Shopping Cart</h1>
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
            Proceed to Checkout
          </button>
        </div>

        <div className="border rounded-sm mt-5">
          <h1 className="text-lg font-medium border-b p-5">Coupon Code</h1>
          <div className="p-5">
            <input
              type="text"
              placeholder="Enter coupon code"
              className="input input-bordered w-full rounded-none"
            />
            <button className="cbtn w-full py-3 mt-3 rounded-none">
              Apply Coupon
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ShoppingCart;
