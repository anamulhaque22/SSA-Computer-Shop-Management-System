import React from "react";

const FilterByAvailability = () => {
  return (
    <div>
      <h3 className="text-base font-medium border-t pt-3">Availability</h3>
      <label className="inline-flex items-center py-5">
        <input
          type="checkbox"
          className="form-checkbox h-5 w-5 accent-primary form-checkbox text-orange-500 bg-white border border-gray-300 rounded checked:bg-orange-500 checked:border-transparent focus:outline-none"
        />
        <span className="ml-2 text-base font-causten-medium text-[#3F4646]">
          Exclude Out of Stock Items
        </span>
      </label>
    </div>
  );
};

export default FilterByAvailability;
