import React from 'react'
import Link from 'next/link'
import { AiOutlineMenu, AiOutlineClose } from 'react-icons/ai'
import { useState } from 'react'

const Navbar = () => {

    //My menu list consist of home and register
    //can be more if needs to be
    let MENU_LIST = [
        {
            text: "Home",
            href: "/",
        },
        {
            text: "Register",
            href: "/register",
        }
    ]

    //Returns a staful value, and function to update it
    //default value: false
    const [nav, setNav] = useState(false)

    //will sets nav to opposite state
    const handleNav = () => { setNav(!nav) }

    return (
        //This is first to my div that is fixed to the corner
        <div className='fixed left-0 top-0 w-full z-10 ease-in duration-300 bg-gray-400'>

            {/* this will make sure that boxes inside of my divs are justified */}
            <div className='max-w-[1240px] m-auto flex justify-between items-center p-4 text-black'>
                
                {/* this is link to my home and styling of my logo */}
                <div>
                    <Link href='/'>
                        <div className='text-2xl font-mono font-extralight tracking-tighter underline underline-offset-1'>
                            Akamali's School Project
                        </div>
                    </Link>
                </div>

                {/* This is my links of my webserver that takes from MENU_LIST */}
                {/* It will loop my links and names */}
                <ul className='hidden sm:flex '>
                    {
                        MENU_LIST.map((mapthis) => (
                            <li className='p-5 font-mono text-xl font-extrabold'>
                                <Link href={mapthis.href}>{mapthis.text}</Link>
                            </li>
                        ))
                    }
                </ul>

                {/* Mobile button */}
                {/* Mobile buttons will show if certain displays are smaller */}
                {/* Using my function handleNav will see if it is true or false */}
                <div onClick={handleNav} className='block sm:hidden z-10'>
                    {/* if nav is true then Close else Menu */}
                    {nav ? <AiOutlineClose size={20} /> : <AiOutlineMenu size={20} />}
                </div>

                {/* Mobile Menu */}
                <div className={nav ? 'sm:hidden absolute top-0 left-0 right-0 bottom-0 flex justify-center items-center w-full h-screen text-center ease-in duration-300  border-8 border-cyan-200' : 'sm:hidden absolute top-0 left-[-100%] right-0 bottom-0 flex justify-center items-center w-full h-screen text-center ease-in duration-300  border-8 border-cyan-200'}>
                    <ul>
                        {

                            //Loop of MENU_LIST, names and links
                            MENU_LIST.map((mapthis) => (
                                <li className='p-4 text-3xl border-8 border-green-300'>
                                    <Link href={mapthis.href}>{mapthis.text}</Link>
                                </li>
                            ))
                        }
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default Navbar