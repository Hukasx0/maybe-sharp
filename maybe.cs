/*
    MIT License

    Copyright (c) 2023 Hubert Kasperek

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

namespace MaybeSharp {
    // "Maybe" class definition, T means it accepts any type
    public class Maybe<T>
    {
    // value is private and immutable (similiar to Haskell)
    private readonly T this_value;
    
    // private constructor
    private Maybe(T val)
    {
        this_value = val;
    }
    
    // creating "Maybe" instance without value - "None", which is inspired by Rust language 
    // Maybe<string>.None;   // for example creates Maybe instance with type string with "None"
    public static Maybe<T> None => new Maybe<T>(default(T));
    
    // creating "Maybe" instance with value - "Some", also inspired by Rust language
    // Maybe<string>.Some("hello");
    public static Maybe<T> Some(T value)
        {
            if (value != null)
            {
                return new Maybe<T>(value);
            }
            else 
            {
                return None;
            }
        }

        // Method that works similiar to Match in Rust language
        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            if (this_value != null) 
            {
                return some(this_value);
            } 
            else
            {
                return none();
            }
        }
    }

    public static class MaybeExt 
    {
        // method that works similiar to unwrap() in Rust Language, but instead of crashing program, it returns empty value
        public static T Unwrap<T>(this Maybe<T> maybe) 
        {
            return maybe.Match(
                some: value => value,
                none: () => default(T)
            );
        }

        // method that works similiar to unwrap_or() in Rust language
        public static T Unwrap_or<T>(this Maybe<T> maybe, Func<T> default_value_function) 
        {
            return maybe.Match(
                some: value => value,
                none: default_value_function
            );
        }

        // method that works like unwrap() in Rust language
        public static T Unwrap_panic<T>(this Maybe<T> maybe)
        {
            return maybe.Match(
                some: value => value,
                none: () => { 
                    Environment.Exit(1);
                    return default(T);
                }
            );
        }
    }
}
