import React from 'react';
import { useField, splitFormProps } from "react-form";

export const TextField = ({ name, type, placeholder }) => {
    const { getInputProps } = useField(name);
    return (
        <input {...getInputProps()} className="form-control" type={type} placeholder={placeholder || name} />
    );
};

export const Select = (props) => {
    const [field, fieldOptions, { description, defaultValue, className, options, ...rest }] = splitFormProps(props);

    const {
        value = defaultValue,
        setValue
    } = useField(field, fieldOptions)

    const handleSelectChange = (event) => {
        setValue(event.target.value)
    }

    return (
        <select {...rest} className={`custom-select${className ? ` ${className}` : ""}`} value={value} onChange={handleSelectChange}>
            <option disabled value={null} >--{description}--</option>
            {options.map(o => (
                <option key={o.value} value={o.value}>
                    {o.text}
                </option>
            ))}
        </select>
    );
};

export const SelectWithDefaultOption = (props) => {
    const [field, fieldOptions, { description, defaultValue, defaultText, className, options, ...rest }] = splitFormProps(props);

    const {
        value = defaultValue,
        setValue
    } = useField(field, fieldOptions)

    const handleSelectChange = (event) => {
        setValue(event.target.value)
    }

    return (
        <select {...rest} className={`custom-select${className ? ` ${className}` : ""}`} value={value} onChange={handleSelectChange}>
            <option disabled value={null} >--{description}--</option>
            <option key={defaultValue} value={defaultValue}>
                {defaultText}
            </option>
            {options.map(o => (
                <option key={o.value} value={o.value}>
                    {o.text}
                </option>
            ))}
        </select>
    );
};