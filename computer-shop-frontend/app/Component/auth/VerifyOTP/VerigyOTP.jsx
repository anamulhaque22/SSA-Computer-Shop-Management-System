"use client";
import React from "react";

const VerigyOTP = () => {
  const [otp, setOTP] = React.useState("");
  return (
    <div className="container flex justify-center items-center h-[70vh] bg-white">
      <div className="py-5 shadow-md border rounded-md w-[424px] bg-white">
        <div className="border-b flex justify-center ">
          <h3 className="text-xl font-semibold border-b-2 border-b-[#FA8232] text-center inline-block mb-4 pb-1">
            Forget Password
          </h3>
        </div>
        <form className="px-5">
          <div className="form-control w-full">
            <label className="label">
              <span
                className={"font-causten-semi-bold text-base text-[#3C4242]"}
              >
                Verify OTP
              </span>
            </label>
            <input
              name="otp"
              type="text"
              value={otp}
              placeholder=""
              onChange={(e) => setOTP(e.target.value)}
              className="input  input-bordered w-full focus:outline-none "
            />
          </div>
          <button type="submit" className="uppercase cbtn w-full mt-4 py-2">
            Verify OTP Code
          </button>
        </form>
      </div>
    </div>
  );
};

export default VerigyOTP;
