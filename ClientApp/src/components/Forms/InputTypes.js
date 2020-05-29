import React from 'react';
import { useField, splitFormProps } from "react-form";

export const TextField = ({ name, type }) => {
    const { getInputProps } = useField(name);
    return (
        <input {...getInputProps()} className="form-control" type={type} placeholder={name} />
    );
};

export const Select = (props) => {
    const [field, fieldOptions, { description, defaultValue, defaultText, options, ...rest }] = splitFormProps(props);

    const {
        value = null,
        setValue
    } = useField(field, fieldOptions)

    const handleSelectChange = (event) => {
        setValue(event.target.value)
    }

    return (
        <select {...rest} className="custom-select" value={value} onChange={handleSelectChange}>
            <option disabled value={null} >--{description}--</option>
            <option value={defaultValue}>{defaultText}</option>
            {options.map(o => (
                <option key={o.value} value={o.value}>
                    {o.text}
                </option>
            ))}
        </select>
    );
}