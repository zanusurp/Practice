import PropTypes from 'prop-types';
import {useLocation} from 'react-router-dom'
import Button from './Button'


const Header = ({title, onAdd, showAdd}) => {
    // const onClick = () =>{
    //     console.log('click')
    // }
    return (
        <header className='header'>
            
            <h1 >{title}</h1>
            <Button color={showAdd ? 'red' : 'green'} text={showAdd ?'Close' : 'Add'} onClick={onAdd} />
            
        </header>
    )
}

Header.defaultProps = {
    title:'Tack Tacker Props'
}
Header.propTypes = {
    title:PropTypes.string.isRequired
}
//css
// const headingStyle = {
//     color:'red', backgroundColor:'black'

// }

export default Header
