import React from "react";

const FilterByBrand = () => {
  return (
    <div>
      <h3 className="text-base font-medium border-t pt-3">Brand</h3>
      <div className="flex flex-col py-5">
        <div className="grid grid-cols-2 gap-y-3">
          <label className="inline-flex items-center">
            <input
              type="checkbox"
              className="form-checkbox h-5 w-5 accent-primary form-checkbox text-orange-500 bg-white border border-gray-300 rounded checked:bg-orange-500 checked:border-transparent focus:outline-none"
            />
            <span className="ml-2 text-base font-causten-medium text-[#3F4646]">
              Nike
            </span>
          </label>
          <label className="inline-flex items-center">
            <input
              type="checkbox"
              className="form-checkbox h-5 w-5 text-primary"
            />
            <span className="ml-2 text-base font-causten-medium text-[#3F4646]">
              Adidas
            </span>
          </label>
          <label className="inline-flex items-center">
            <input
              type="checkbox"
              className="form-checkbox h-5 w-5 text-primary"
            />
            <span className="ml-2 text-base font-causten-medium text-[#3F4646]">
              Puma
            </span>
          </label>
          <label className="inline-flex items-center">
            <input
              type="checkbox"
              className="form-checkbox h-5 w-5 text-primary"
            />
            <span className="ml-2 text-base font-causten-medium text-[#3F4646]">
              Reebok
            </span>
          </label>
        </div>
      </div>
    </div>
  );
};

export default FilterByBrand;
