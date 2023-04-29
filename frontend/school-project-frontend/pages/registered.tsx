import React from 'react'
import Link from 'next/link'

function registered() {
    return (
        <>
            <div className='py-32 px-32'>

                <div className=' text-3xl'>
                    Thanks for registering!
                </div>
                <div className='py-4' />
                <button className='py-5 border-2 border-black px-5 '>
                    <Link href={'/'}>Go back to home</Link>
                </button>
            </div>
        </>
    )
}

export default registered