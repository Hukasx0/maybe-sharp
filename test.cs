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

using System;
using MaybeSharp;

namespace Program
{
    class Program
    {
        static void Main()
        {
            // "Maybe" can work with any C# type
                Maybe<int> maybe_int = Maybe<int>.Some(13);
                Maybe<double> maybe_double = Maybe<double>.Some(1.9);
                Maybe<bool> maybe_bool = Maybe<bool>.Some(true);
                Maybe<char> maybe_char = Maybe<char>.Some('A');
                Maybe<string> maybe_string = Maybe<string>.Some("Hello world");

                Maybe<string> none_string = Maybe<string>.None;

                // "Maybe" can even be used like this
                Maybe<Maybe<Maybe<bool>>> nested_maybe_bool = Maybe<Maybe<Maybe<bool>>>.Some(
                                                                Maybe<Maybe<bool>>.Some(
                                                                    Maybe<bool>.Some(true)
                                                                )
                                                              );
            //

            // method tests
            test_unwrap_method();
            test_unwrap_or_method();
            test_match_method();
        }

        static void test_unwrap_method()
        {
             // Create "Maybe" instance with value
            Maybe<string> maybe_value = Maybe<string>.Some("Test one");

            // Create "Maybe" instance without value
            Maybe<string> maybe_none = Maybe<string>.None;

            // Use .Unwrap() method on both
            string maybe_value_unwrapped = maybe_value.Unwrap();
            string maybe_none_unwrapped = maybe_none.Unwrap();

            Console.WriteLine("Unwrapped Value: " + maybe_value_unwrapped); // should print in the console: "Unwrapped Value: Test one"
            Console.WriteLine("Unwrapped None: " + maybe_none_unwrapped);   // should print in the console: "Unwrapped None: "
        }

        static void test_unwrap_or_method()
        {
            // Create "Maybe" instance with value
            Maybe<string> maybe_value = Maybe<string>.Some("Test two");

            // Create "Maybe" instance without value
            Maybe<string> maybe_none = Maybe<string>.None;

            // use .Unwrap_or() method on both
            string maybe_value_unwrapped = maybe_value.Unwrap_or(() => "Default Value");
            string maybe_none_unwrapped = maybe_none.Unwrap_or(() => "Default Value");

            Console.WriteLine("Unwrap_or Value: " + maybe_value_unwrapped); // should print in the console: "Unwrap_or Value: Test two"
            Console.WriteLine("Unwrap_or None: " + maybe_none_unwrapped);   // should print in the console: "Unwrap_or Value: Default value"
        }

        static void test_match_method()
        {
            // Create "Maybe" instance with value
            Maybe<string> maybe_value = Maybe<string>.Some("Test three");

            // Create "Maybe" instance without value
            Maybe<string> maybe_none = Maybe<string>.None;

            // Use Match method on first value
            string result_match_value = maybe_value.Match(
                some: value => "Matched Value: " + value,
                none: () => "None"
            );

            // Use Match method on second value
            string result_match_none = maybe_none.Match(
                some: value => "Matched Value: " + value,
                none: () => "None"
            );

            Console.WriteLine("Matched Result with Value: " + result_match_value); // should print in the console: "Matched Result with Value: Matched Value: Test three"
            Console.WriteLine("Matched Result with None: " + result_match_none);   // should print in the console: "Matched Result with None: None"
        }
    }
}
