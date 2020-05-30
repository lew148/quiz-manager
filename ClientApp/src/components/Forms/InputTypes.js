import React from 'react';
import { useField, splitFormProps } from "react-form";
import { post } from '../../Api';
import { FaTrash, FaPlus } from 'react-icons/fa';

const returnAdditionalClassNameIfExists = (additionalClassName) => {
    return additionalClassName ? ` ${additionalClassName}` : ""
}

export const TextField = ({ name, type, placeholder, additionalClassName }) => {
    const { getInputProps } = useField(name);
    return (
        <input {...getInputProps()} className={`form-control${returnAdditionalClassNameIfExists(additionalClassName)}`} type={type} placeholder={placeholder || name} />
    );
};

export const Select = (props) => {
    const [field, fieldOptions, { description, defaultValue, className, handleQuestionSelectChange, options, ...rest }] = splitFormProps(props);

    const {
        value = defaultValue,
        setValue
    } = useField(field, fieldOptions)

    const handleSelectChange = (event) => {
        setValue(event.target.value);
        handleQuestionSelectChange && handleQuestionSelectChange(event.target.value);
    }

    return (
        <select {...rest} className={`custom-select${returnAdditionalClassNameIfExists(className)}`} value={value} onChange={handleSelectChange}>
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

export const DeleteButton = ({ confirmText, apiDeleteRoute }) => {
    const handleClick = async () => {
        // eslint-disable-next-line no-restricted-globals
        var deleteComfirmed = confirm(confirmText)
        if (deleteComfirmed) {
            await post(apiDeleteRoute)
            window.location.reload();
        }
    }

    return (
        <button type="button" onClick={handleClick} className="delete-button"><FaTrash /></button>
    );
};

export const AddButton = () => <button className="btn btn-success btn-sm" type="submit"><FaPlus /></button>
                